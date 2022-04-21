namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;

using MediatR;
using PaymentsGatewayApi.Application.Common.Wrappers;
using System;

public class GetPaymentByIdQuery : IRequest<Result<PaymentDTO>>
{
    public string Id { get; set; }
}