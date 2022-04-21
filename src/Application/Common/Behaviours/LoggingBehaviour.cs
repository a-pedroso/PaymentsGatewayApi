namespace PaymentsGatewayApi.Application.Common.Behaviours;

using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;
    private readonly ICurrentClientService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentClientService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var clientId = _currentUserService.ClientId ?? string.Empty;

        _logger.LogInformation("PaymentsGatewayApi Request: {Name} {@ClientId}  ",
            requestName, clientId);

        return Task.CompletedTask;
    }
}