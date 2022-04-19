namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;

using PaymentsGatewayApi.Application.Common.Wrappers;
using MediatR;
using System;

public class GetPaymentByIdQuery : IRequest<Result<PaymentDTO>>
{
    public string Id { get; set; }
}
