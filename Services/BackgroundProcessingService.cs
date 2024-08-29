using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace crudNet.Services
{
    public class BackgroundProcessingService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public BackgroundProcessingService(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var csvProcessor = scope.ServiceProvider.GetRequiredService<CsvProcessor>();
            var resultService = scope.ServiceProvider.GetRequiredService<ElectionResultService>();
          
        }
    }
}
