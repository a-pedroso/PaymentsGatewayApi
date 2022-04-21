namespace PaymentsGatewayApi.Application.Features.Payments;

using System;

/// <summary>
/// from: https://www.checkout.com/docs/payments/accept-payments/request-a-card-payment#Response_example
/// </summary>
public record PaymentDTO(
    string Id,
    string ActionId,
    int Amount,
    string Currency,
    bool Approved,
    string Status,
    string AuthCode,
    string Eci,
    string SchemeId,
    string ResponseCode,
    string ResponseSummary,
    RiskDTO Risk,
    SourceDTO Source,
    CustomerDTO Customer,
    DateTime ProcessedOn,
    string Reference);


public record RiskDTO(
    bool Flagged);


public record SourceDTO(
    string Id,
    string Type,
    int ExpiryMonth,
    int ExpiryYear,
    string Scheme,
    string Last4,
    string Fingerprint,
    string Bin,
    string CardType,
    string CardCategory,
    string Issuer,
    string IssuerCountry,
    string ProductId,
    string ProductType,
    string AvsCheck,
    string CvvCheck);

public record CustomerDTO(string Id);