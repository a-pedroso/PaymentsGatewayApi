namespace PaymentsGatewayApi.Application.Common.Interfaces.Services;

using System;

public interface ICkoBankSimulator
{
    CkoBankSimulatorResponse ProcessCardPayment(int amount, string currency, long cardNumber, int cvv, int expiryMonth, int expiryYear);
    CkoBankSimulatorResponse ProcessTokenPayment(int amount, string currency, string token);
}

public record CkoBankSimulatorResponse(
    bool Approved,
    string Status,
    string AuthCode,
    string Eci,
    string SchemeId,
    string ResponseCode,
    string ResponseSummary,
    bool Flagged,
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
    string CvvCheck,
    DateTime ProcessedOn);


//"approved": true,
//  "status": "Authorized",
//  "auth_code": "770687",
//  "eci": "05",
//  "scheme_id": "638284745624527",
//  "response_code": "10000",
//  "response_summary": "Approved",
//  "risk": {
//    "flagged": false
//  },
//  "source": {
//    "id": "src_nwd3m4in3hkuddfpjsaevunhdy",
//    "type": "card",
//    "expiry_month": 9,
//    "expiry_year": 2022,
//    "scheme": "Visa",
//    "last4": "4242",
//    "fingerprint": "F31828E2BDABAE63EB694903825CDD36041CC6ED461440B81415895855502832",
//    "bin": "424242",
//    "card_type": "Credit",
//    "card_category": "Consumer",
//    "issuer": "JPMORGAN CHASE BANK NA",
//    "issuer_country": "US",
//    "product_id": "A",
//    "product_type": "Visa Traditional",
//    "avs_check": "S",
//    "cvv_check": ""
//  },