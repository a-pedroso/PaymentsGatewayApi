namespace PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class CustomerEFO
{
    [Key]
    public string Id { get; set; }
}