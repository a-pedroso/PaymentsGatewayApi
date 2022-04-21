namespace PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

using PaymentsGatewayApi.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Payments")]
public class PaymentEFO : AuditableEntity
{
    [Key]
    public string Id { get; set; }

    public string ActionId { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    [MaxLength(3)]
    public string Currency { get; set; }

    [Required]
    public bool Approved { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string AuthCode { get; set; }

    public string Eci { get; set; }

    public string SchemeId { get; set; }

    [Required]
    public string ResponseCode { get; set; }

    [Required]
    public string ResponseSummary { get; set; }

    [Required]
    [ForeignKey("RiskId")]
    public RiskEFO Risk { get; set; }

    [Required]
    [ForeignKey("SourceId")]
    public SourceEFO Source { get; set; }

    [ForeignKey("CustomerId")]
    public CustomerEFO Customer { get; set; }

    public DateTime ProcessedOn { get; set; }

    public string Reference { get; set; }

    internal Payment ToDomainEntity()
    {
        return new Payment(
            Id,
            ActionId,
            Amount,
            (PaymentCurrency)Currency,
            Approved,
            (PaymentStatus)Status,
            AuthCode,
            Eci,
            SchemeId,
            ResponseCode,
            ResponseSummary,
            new Risk(Risk.Flagged),
            new Source(Source.Id,
                       (PaymentSourceType)Source.Type,
                       Source.ExpiryMonth,
                       Source.ExpiryYear,
                       Source.Scheme,
                       Source.Last4,
                       Source.Fingerprint,
                       Source.Bin,
                       Source.CardType,
                       Source.CardCategory,
                       Source.Issuer,
                       Source.IssuerCountry,
                       Source.ProductId,
                       Source.ProductType,
                       Source.AvsCheck,
                       Source.CvvCheck),
            new Customer(Customer.Id),
            ProcessedOn,
            Reference);
    }
}