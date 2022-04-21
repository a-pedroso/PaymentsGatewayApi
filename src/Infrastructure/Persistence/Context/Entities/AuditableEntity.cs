namespace PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public abstract class AuditableEntity
{
    [Required]
    public DateTime Created { get; set; }

    [Required]
    [MaxLength(30)]
    public string CreatedBy { get; set; }

    public DateTime? Updated { get; set; }

    [MaxLength(30)]
    public string UpdatedBy { get; set; }
}