using ClothesStore.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace ClothesStrore.Application.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger { get; }

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request {@RequestName} , {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.Now);

        var result = await next();

        _logger.LogInformation("Completed request {@RequestName} , {@DateTimeUtc}",
          typeof(TRequest).Name, DateTime.Now);
        return result;

    }
}
