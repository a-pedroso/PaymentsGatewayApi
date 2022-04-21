﻿namespace PaymentsGatewayApi.WebApi.Extensions.StartupExtensions;

using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PaymentsGatewayApi.Application.Common.Exceptions;

public static class ProblemDetailsExtension
{
    public static IServiceCollection AddProblemDetailsExtension(this IServiceCollection services)
    {
        return services.AddProblemDetails(x =>
        {
            x.Map<NotFoundException>(ex => new StatusCodeProblemDetails(StatusCodes.Status404NotFound));
            x.Map<ValidationException>(ex => new StatusCodeProblemDetails(StatusCodes.Status400BadRequest));
            x.Map<BadRequestException>(ex => new StatusCodeProblemDetails(StatusCodes.Status400BadRequest));
        });
    }


    public static IApplicationBuilder UseProblemDetailsExtension(this IApplicationBuilder app)
    {
        return app.UseProblemDetails();
    }
}