namespace PaymentsGatewayApi.Application.Common.Behaviours;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using PaymentsGatewayApi.Application.Common.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception ex) when (ex is ValidationException || ex is ApplicationLayerException)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogWarning(ex, "PaymentsGatewayApi Request: Exception for Request {Name}", requestName);

            throw;
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "PaymentsGatewayApi Request: Unhandled Exception for Request {Name}", requestName);

            throw;
        }
    }
}