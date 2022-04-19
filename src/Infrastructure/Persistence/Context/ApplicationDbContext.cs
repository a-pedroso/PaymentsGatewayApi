namespace PaymentsGatewayApi.Infrastructure.Persistence.Context;

using Microsoft.EntityFrameworkCore;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;
using System.Threading;
using System.Threading.Tasks;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentClientService _currentClientService;
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentClientService currentUserService,
        IDateTime dateTime) : base(options)
    {
        _currentClientService = currentUserService;
        _dateTime = dateTime;
    }

    public DbSet<PaymentEFO> Payments { get; set; }

    public DbSet<SourceEFO> Sources { get; set; }

    public DbSet<CustomerEFO> Customers { get; set; }

    public DbSet<RiskEFO> Risks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentClientService.ClientId;
                    entry.Entity.Created = _dateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _currentClientService.ClientId;
                    entry.Entity.Updated = _dateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
