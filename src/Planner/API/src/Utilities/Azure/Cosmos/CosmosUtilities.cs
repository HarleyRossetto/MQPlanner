using System.Text;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace Planner.Api.Utilities.Azure.Cosmos {
    public class CosmosUtilities {

        public static async Task<ResponseMessage> UpsertToContainerAsync<T>(T item, Container container, PartitionKey partitionKey, CancellationToken ct = default) {
            using (var stream = await ToStream<T>(item)) {
                using (var response = await container.UpsertItemStreamAsync(stream, partitionKey, null, ct)) {
                    return response;
                }
            }
        }

        private static async Task<Stream> ToStream<T>(T input) {
            var payload = new MemoryStream();
            using (var streamWriter = new StreamWriter(payload, encoding: Encoding.Default, bufferSize: 1024, leaveOpen: true)) {
                using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter)) {
                    jsonWriter.Formatting = Formatting.None;
                    new JsonSerializer().Serialize(jsonWriter, input);
                    await jsonWriter.FlushAsync();
                    await streamWriter.FlushAsync();
                }
            }

            payload.Position = 0;
            return payload;
        }

        public async Task<T?> ReadFromStreamAsync<T>(Container container, PartitionKey partitionKey, string id, CancellationToken cancellationToken = default) where T : new() {
            using (var responseMessage = await container.ReadItemStreamAsync(id, partitionKey, null, cancellationToken)) {
                if (responseMessage.IsSuccessStatusCode) {
                    using (var reader = new StreamReader(responseMessage.Content)) {
                        using (JsonTextReader jsonTextReader = new(reader)) {
                            return new JsonSerializer().Deserialize<T>(jsonTextReader) ?? default;
                        }
                    }
                } else {
                    return default;
                }
            }
        }
    }
}