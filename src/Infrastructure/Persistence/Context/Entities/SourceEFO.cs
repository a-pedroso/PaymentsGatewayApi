namespace PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Sources")]
public class SourceEFO
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public int ExpiryMonth { get; set; }

    [Required]
    public int ExpiryYear { get; set; }

    [Required]
    public string Scheme { get; set; }

    [Required]
    public string Last4 { get; set; }

    public string Fingerprint { get; set; }
    public string Bin { get; set; }
    public string CardType { get; set; }
    public string CardCategory { get; set; }
    public string Issuer { get; set; }
    public string IssuerCountry { get; set; }
    public string ProductId { get; set; }
    public string ProductType { get; set; }
    public string AvsCheck { get; set; }
    public string CvvCheck { get; set; }
}