namespace Planner.Api.Services.Telemetry {
    public interface ITelemetryProvider {
        public Task LogCounter(string counterName, int incrementBy = 1);
        public Task LogUnitUpdated(string unitCode, string newVersion, string oldVersion);
        public Task LogUnitAdded(string unitCode, string version);
    }
}