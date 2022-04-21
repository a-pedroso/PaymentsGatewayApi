namespace PaymentsGatewayApi.Application.Common.Behaviours;

using MediatR;
using Microsoft.Extensions.Logging;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentClientService _currentUserService;

    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentClientService currentUserService)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var clientId = _currentUserService.ClientId ?? string.Empty;

            _logger.LogWarning("PaymentsGatewayApi Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@ClientId}",
                requestName, elapsedMilliseconds, clientId);
        }

        return response;
    }
}