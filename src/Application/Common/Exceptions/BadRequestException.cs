namespace PaymentsGatewayApi.Application.Common.Exceptions;

using System;
public class BadRequestException : ApplicationLayerException
{
    public BadRequestException(string message) : base(message)
    {

    }
}