namespace PaymentsGatewayApi.Application.Common.Exceptions;

using System;

public abstract class ApplicationLayerException : Exception
{
    public ApplicationLayerException()
        : base()
    {
    }

    public ApplicationLayerException(string message)
        : base(message)
    {
    }

    public ApplicationLayerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
