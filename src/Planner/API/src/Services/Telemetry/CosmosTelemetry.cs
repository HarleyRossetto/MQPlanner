using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HXR.Utilities.DateTime;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Planner.Api.Utilities.Azure.Cosmos;

namespace Planner.Api.Services.Telemetry {
    public class CosmosTelemetry : ITelemetryProvider {
        private readonly CosmosClient _cosmosClient;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly Container cosmosTelemetryContainer;

        public CosmosTelemetry(CosmosClient cosmosClient, IConfiguration cfg, IDateTimeProvider dateTimeProvider) {
            _cosmosClient = cosmosClient;

            var cosmosDatabase = _cosmosClient.GetDatabase(cfg["Azure:Cosmos:DatabaseId"]);
            cosmosTelemetryContainer = cosmosDatabase.CreateContainerIfNotExistsAsync(cfg["Azure:Cosmos:Containers:Telemetry"], $"/{nameof(TelemetryMessage.Type)}").Result;
            _dateTimeProvider = dateTimeProvider;
        }


        private async Task SendTelemetry(TelemetryMessage msg) {
            var response = await CosmosUtilities.UpsertToContainerAsync(msg, cosmosTelemetryContainer, new PartitionKey(msg.Type));
            if (!response.IsSuccessStatusCode) {
                // Do what you want.
                int i = 0;
            }
        }

        public async Task LogCounter(string counterName, int incrementBy = 1) {
            await SendTelemetry(new CounterTelemetry(counterName, incrementBy, _dateTimeProvider.DateTimeNow));
        }

        public async Task LogUnitUpdated(string unitCode, string newVersion, string oldVersion) {
            await SendTelemetry(new UnitUpdatedTelemetry(unitCode, newVersion, oldVersion, _dateTimeProvider.DateTimeNow));
        }

        public async Task LogUnitAdded(string unitCode, string version) {
            await SendTelemetry(new UnitAddedTelemetry(unitCode, version, _dateTimeProvider.DateTimeNow));
        }
    }

    public enum TelemetryType {
        Error,
        Counter,
        Metric,
        Information,
        NewUnit,
        UpdatedUnit
    }

    public record TelemetryMessage {
        /// <summary>
        /// Cosmos ID
        /// </summary>
        [JsonProperty("id")]
        public string Id => $"{Type.ToString()}{Time.ToUniversalTime().ToString()}";
        public string Type { get; init; }
        public DateTime Time { get; set; }
        public TelemetryMessage(TelemetryType telemType, DateTime time) {
            Type = telemType.ToString();
            Time = time;
        }
    }

    public record CounterTelemetry : TelemetryMessage {
        public string Name { get; init; }
        public int IncrementedValue { get; init; } = 1;

        public CounterTelemetry(string counterName, int incrementBy, DateTime time) : base(TelemetryType.Counter, time) {
            Name = counterName;
            IncrementedValue = incrementBy;
        }
    }

    public record UnitAddedTelemetry : TelemetryMessage {
        public string UnitCode { get; init; } = string.Empty;
        public string Version { get; init; } = string.Intern("-1");


        public UnitAddedTelemetry(string code, string version, DateTime time) : base(TelemetryType.NewUnit, time) {
            UnitCode = code;
            Version = version;
        }
    }

        public record UnitUpdatedTelemetry : TelemetryMessage {
        public string UnitCode { get; init; } = string.Empty;
        public string NewVersion { get; init; } = string.Intern("-1");
        public string OldVersion { get; init; } = string.Intern("-1");


        public UnitUpdatedTelemetry(string code, string newVersion, string oldVersion, DateTime time) : base(TelemetryType.UpdatedUnit, time) {
            UnitCode = code;
            NewVersion = newVersion;
            OldVersion = oldVersion;
        }
    }
}