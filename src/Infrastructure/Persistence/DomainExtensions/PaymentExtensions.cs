namespace PaymentsGatewayApi.Infrastructure.Persistence.DomainExtensions;

using PaymentsGatewayApi.Domain.Entities;
using PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

public static class PaymentExtensions
{
    public static PaymentEFO ToEFO (this Payment p)
    {
        return new PaymentEFO()
        {
            Id = p.Id,
            ActionId = p.ActionId,
            Amount = p.Amount,
            Currency = p.Currency,
            Approved = p.Approved,
            Status = p.Status,
            AuthCode = p.AuthCode,
            Eci = p.Eci,
            SchemeId = p.SchemeId,
            ResponseCode = p.ResponseCode,
            ResponseSummary = p.ResponseSummary,
            Risk = new RiskEFO() { Flagged = p.Risk.Flagged },
            Source = new SourceEFO() 
            {
                Id = p.Source.Id,
                Type = p.Source.Type,
                ExpiryMonth = p.Source.ExpiryMonth,
                ExpiryYear = p.Source.ExpiryYear,
                Scheme = p.Source.Scheme,
                Last4 = p.Source.Last4,
                Fingerprint = p.Source.Fingerprint,
                Bin = p.Source.Bin,
                CardType = p.Source.CardType,
                CardCategory = p.Source.CardCategory,
                Issuer = p.Source.Issuer,
                IssuerCountry = p.Source.IssuerCountry,
                ProductId = p.Source.ProductId,
                ProductType = p.Source.ProductType,
                AvsCheck = p.Source.AvsCheck,
                CvvCheck = p.Source.CvvCheck
            },
            Customer = new CustomerEFO() { Id = p.Customer.Id },
            ProcessedOn = p.ProcessedOn,
            Reference = p.Reference
        };
    }
}
