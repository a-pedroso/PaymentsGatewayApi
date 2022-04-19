namespace PaymentsGatewayApi.Infrastructure.Shared.Services;

using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using System;

public class CkoBankSimulator : ICkoBankSimulator
{
    public CkoBankSimulatorResponse ProcessCardPayment(int amount, string currency, long cardNumber, int cvv, int expiryMonth, int expiryYear)
    {
        return GetMock(expiryMonth, expiryYear, cardNumber);
    }

    public CkoBankSimulatorResponse ProcessTokenPayment(int amount, string currency, string token)
    {
        return GetMock(DateTime.UtcNow.Month, DateTime.UtcNow.Year + 1, 1234567890123456);
    }

    private static CkoBankSimulatorResponse GetMock(int expiryMonth, int expiryYear, long cardNumber)
    {
        return new CkoBankSimulatorResponse(
            Approved: true,
            Status: "Authorized",
            AuthCode: "770687",
            Eci: "05",
            SchemeId: "638284745624527",
            ResponseCode: "10000",
            ResponseSummary: "Approved",
            Flagged: false,
            Type: "Card",
            ExpiryMonth: expiryMonth,
            ExpiryYear: expiryYear,
            Scheme: "Visa",
            Last4: "" + cardNumber % 10000,
            Fingerprint: "F31828E2BDABAE63EB694903825CDD36041CC6ED461440B81415895855502832",
            Bin: "424242",
            CardType: "Credit",
            CardCategory: "Consumer",
            Issuer: "JPMORGAN CHASE BANK NA",
            IssuerCountry: "US",
            ProductId: "A",
            ProductType: "Visa Traditional",
            AvsCheck: "S",
            CvvCheck: string.Empty,
            ProcessedOn: DateTime.UtcNow);
    }
}