using MediatR;
using Microsoft.Extensions.Logging;
using NSysF.Application.Infraestructure.Persistence;

namespace NSysF.Application.Common
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly NSysFDbContext _context;
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;

        public TransactionBehavior(NSysFDbContext context, ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                await _context.EmpiezaTransaccionAsync();
                var response = await next();
                await _context.CommitTransaccionAsync();

                return response;
            }
            catch (Exception)
            {
                _logger.LogError("Request failed: Rolling back all the changes made to the Context");

                await _context.RollBackTransaccionAsync();
                throw;
            }
        }
    }
}