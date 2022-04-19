namespace PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Risks")]
public class RiskEFO
{
    [Key]
    public Guid Id { get; set; }
    public bool Flagged { get; set; }
}
