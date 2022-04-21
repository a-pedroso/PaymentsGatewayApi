namespace PaymentsGatewayApi.Application.Features.Payments;

using PaymentsGatewayApi.Domain.Entities;

public static class PaymentExtensions
{
    public static PaymentDTO ToDTO(this Payment p)
    {
        return new PaymentDTO(
            p.Id,
            p.ActionId,
            p.Amount,
            p.Currency,
            p.Approved,
            p.Status,
            p.AuthCode,
            p.Eci,
            p.SchemeId,
            p.ResponseCode,
            p.ResponseSummary,
            new RiskDTO(
                p.Risk.Flagged),
            new SourceDTO(
                p.Source.Id,
                p.Source.Type,
                p.Source.ExpiryMonth,
                p.Source.ExpiryYear,
                p.Source.Scheme,
                p.Source.Last4,
                p.Source.Fingerprint,
                p.Source.Bin,
                p.Source.CardType,
                p.Source.CardCategory,
                p.Source.Issuer,
                p.Source.IssuerCountry,
                p.Source.ProductId,
                p.Source.ProductType,
                p.Source.AvsCheck,
                p.Source.CvvCheck),
            new CustomerDTO(
                p.Customer.Id),
                p.ProcessedOn,
                p.Reference);
    }
}