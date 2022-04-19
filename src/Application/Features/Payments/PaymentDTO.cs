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

/*
{
  "id": "pay_mbabizu24mvu3mela5njyhpit4",
  "action_id": "act_mbabizu24mvu3mela5njyhpit4",
  "amount": 6500,
  "currency": "USD",
  "approved": true,
  "status": "Authorized",
  "auth_code": "770687",
  "eci": "05",
  "scheme_id": "638284745624527",
  "response_code": "10000",
  "response_summary": "Approved",
  "risk": {
    "flagged": false
  },
  "source": {
    "id": "src_nwd3m4in3hkuddfpjsaevunhdy",
    "type": "card",
    "expiry_month": 9,
    "expiry_year": 2022,
    "scheme": "Visa",
    "last4": "4242",
    "fingerprint": "F31828E2BDABAE63EB694903825CDD36041CC6ED461440B81415895855502832",
    "bin": "424242",
    "card_type": "Credit",
    "card_category": "Consumer",
    "issuer": "JPMORGAN CHASE BANK NA",
    "issuer_country": "US",
    "product_id": "A",
    "product_type": "Visa Traditional",
    "avs_check": "S",
    "cvv_check": ""
  },
  "customer": {
    "id": "cus_udst2tfldj6upmye2reztkmm4i"
  },
  "processed_on": "2019-01-25T11:03:36Z",
  "reference": "ORD-5023-4E89",
  "_links": {
    "self": {
      "href": "https://api.sandbox.checkout.com/payments/pay_mbabizu24mvu3mela5njyhpit4"
    },
    "actions": {
      "href": "https://api.sandbox.checkout.com/payments/pay_mbabizu24mvu3mela5njyhpit4/actions"
    },
    "capture": {
      "href": "https://api.sandbox.checkout.com/payments/pay_mbabizu24mvu3mela5njyhpit4/captures"
    },
    "void": {
      "href": "https://api.sandbox.checkout.com/payments/pay_mbabizu24mvu3mela5njyhpit4/voids"
    }
  }
}
 
 */
