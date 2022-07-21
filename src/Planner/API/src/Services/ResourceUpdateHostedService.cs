using System.Diagnostics;
using HXR.Utilities.DateTime;
using Planner.Api.Services.DataAccess;

namespace Planner.Api.Services {
    public class ResourceUpdateHostedService : IHostedService, IDisposable, IAsyncDisposable {
        private readonly ILogger<ResourceUpdateHostedService> _logger;
        private readonly IHandbookDataProvider _handbookDataProvider;
        private readonly IDateTimeProvider _dateTime;
        private Timer? _timer = null;

        public ResourceUpdateHostedService(ILogger<ResourceUpdateHostedService> logger, IHandbookDataProvider handbookDataProvider, IDateTimeProvider dateTime) {
            _logger = logger;
            _handbookDataProvider = handbookDataProvider;
            _dateTime = dateTime;
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            _logger.LogInformation("Resource Update Hosted Service started.");
            _timer = new Timer(UpdateResources, (_handbookDataProvider, _logger, _dateTime), TimeSpan.FromSeconds(15), TimeSpan.FromMinutes(15));

            return Task.CompletedTask;
        }

        private async void UpdateResources(object? state) {
            (IHandbookDataProvider handbook, ILogger<ResourceUpdateHostedService> logger, IDateTimeProvider dateTimeProvider)? deps
                = state as (IHandbookDataProvider, ILogger<ResourceUpdateHostedService>, IDateTimeProvider)?;

            if (deps is null)
                return;

            deps.Value.logger.LogInformation("Updating resources...");
            
            var sw = Stopwatch.StartNew();
            await deps.Value.handbook.GetAllUnits(deps.Value.dateTimeProvider.DateTimeNow.Year);
            sw.Stop();
            
            deps.Value.logger.LogInformation("Resource update took {0} seconds.", sw.Elapsed.Seconds);
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            _timer?.Change(Timeout.Infinite, 0);

            _logger.LogInformation("Resource Update Hosted Service stopped.");

            return Task.CompletedTask;
        }

        public void Dispose() {
            _timer?.Dispose();
        }

        public async ValueTask DisposeAsync() {
            if (_timer is not null)
                await _timer.DisposeAsync().ConfigureAwait(false);

            _timer = null;
        }
    }
}