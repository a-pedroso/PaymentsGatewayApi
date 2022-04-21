namespace PaymentsGatewayApi.Infrastructure.Shared.Services;

using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using System;

public class DateTimeService : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
}