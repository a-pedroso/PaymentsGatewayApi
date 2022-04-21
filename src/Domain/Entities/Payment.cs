namespace PaymentsGatewayApi.Domain.Entities;

using PaymentsGatewayApi.Domain.Common;
using System;

/// <summary>
/// from https://www.checkout.com/docs/payments/accept-payments/request-a-card-payment#Response_example
/// </summary>

public record Payment : BaseEntity<string>
{
    public Payment(
        string id,
        string actionId,
        int amount,
        PaymentCurrency currency,
        bool approved,
        PaymentStatus status,
        string authCode,
        string eci,
        string schemeId,
        string responseCode,
        string responseSummary,
        Risk risk,
        Source source,
        Customer customer,
        DateTime processedOn,
        string reference)
    {
        Id = id;
        ActionId = actionId;
        Amount = amount;
        Currency = currency;
        Approved = approved;
        Status = status;
        AuthCode = authCode;
        Eci = eci;
        SchemeId = schemeId;
        ResponseCode = responseCode;
        ResponseSummary = responseSummary;
        Risk = risk;
        Source = source;
        Customer = customer;
        ProcessedOn = processedOn;
        Reference = reference;
    }

    public override string Id { get; init; }
    public string ActionId { get; init; }
    public int Amount { get; init; }
    public PaymentCurrency Currency { get; init; }
    public bool Approved { get; init; }
    public PaymentStatus Status { get; init; }
    public string AuthCode { get; init; }
    public string Eci { get; init; }
    public string SchemeId { get; init; }
    public string ResponseCode { get; init; }
    public string ResponseSummary { get; init; }
    public Risk Risk { get; init; }
    public Source Source { get; init; }
    public Customer Customer { get; init; }
    public DateTime ProcessedOn { get; init; }
    public string Reference { get; init; }
}