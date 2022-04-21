namespace PaymentsGatewayApi.Domain.Entities;

using System;

public record Source
{
    public Source(
        string id,
        PaymentSourceType type,
        int expiryMonth,
        int expiryYear,
        string scheme,
        string last4,
        string fingerprint,
        string bin,
        string cardType,
        string cardCategory,
        string issuer,
        string issuerCountry,
        string productId,
        string productType,
        string avsCheck,
        string cvvCheck)
    {
        Id = id;
        Type = type;
        ExpiryMonth = expiryMonth;
        ExpiryYear = expiryYear;
        Scheme = scheme;
        Last4 = last4;
        Fingerprint = fingerprint;
        Bin = bin;
        CardType = cardType;
        CardCategory = cardCategory;
        Issuer = issuer;
        IssuerCountry = issuerCountry;
        ProductId = productId;
        ProductType = productType;
        AvsCheck = avsCheck;
        CvvCheck = cvvCheck;
    }

    public string Id { get; init; }
    public PaymentSourceType Type { get; init; }
    public int ExpiryMonth { get; init; }
    public int ExpiryYear { get; init; }
    public string Scheme { get; init; }
    public string Last4 { get; init; }
    public string Fingerprint { get; init; }
    public string Bin { get; init; }
    public string CardType { get; init; }
    public string CardCategory { get; init; }
    public string Issuer { get; init; }
    public string IssuerCountry { get; init; }
    public string ProductId { get; init; }
    public string ProductType { get; init; }
    public string AvsCheck { get; init; }
    public string CvvCheck { get; init; }
}