namespace PaymentsGatewayApi.Application.Features.Payments.Commands.CreatePayment;

using PaymentsGatewayApi.Application.Common.Wrappers;
using MediatR;

/// <summary>
/// request sample: https://www.checkout.com/docs/payments/accept-payments/request-a-card-payment#Request_example
/// requirements: card number, expiry month/date, amount, currency, and cvv.
/// </summary>

public class CreatePaymentCommand : IRequest<Result<PaymentDTO>>
{
    public CreatePaymentCommandSource Source { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; }
    public string Reference { get; set; }
    public CreatePaymentCommandMetadata Metadata { get; set; }
}

public record CreatePaymentCommandSource(
    string Type,
    string Token,
    int ExpiryMonth,
    int ExpiryYear,
    long CardNumber,
    int Cvv);

public record CreatePaymentCommandMetadata(
    string Udf1,
    string CouponCode,
    int PartnerId);