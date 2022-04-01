using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace NSysF.Application.Common
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            this._logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestNombre = typeof(TRequest).Name;

            this._logger.LogInformation($"Peticion de API : { requestNombre }, { request }");

           return Task.CompletedTask;
        }
    }
}
