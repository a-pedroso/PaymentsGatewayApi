namespace PaymentsGatewayApi.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using PaymentsGatewayApi.Application.Common.Wrappers;
using PaymentsGatewayApi.Application.Features.Payments;
using PaymentsGatewayApi.Domain.Entities;
using PaymentsGatewayApi.Infrastructure.Persistence.Context;
using PaymentsGatewayApi.Infrastructure.Persistence.Context.Entities;
using PaymentsGatewayApi.Infrastructure.Persistence.DomainExtensions;
using System;
using System.Linq;
using System.Threading.Tasks;

public class PaymentRepository : IPaymentsRepository
{
    private readonly DbSet<PaymentEFO> _payments;
    private readonly ApplicationDbContext _dbContext;

    public PaymentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _payments = dbContext.Set<PaymentEFO>();
    }

    public async Task<Payment> AddAsync(Payment entity)
    {
        PaymentEFO efo = entity.ToEFO();

        efo.Id = $"pay_{Guid.NewGuid():N}";
        efo.ActionId = $"act_{Guid.NewGuid():N}";
        efo.Source.Id = $"src_{Guid.NewGuid():N}";
        efo.Customer.Id = $"cus_{Guid.NewGuid():N}";

        await _payments.AddAsync(efo);
        await _dbContext.SaveChangesAsync();

        return efo?.ToDomainEntity();
    }

    public async Task<Payment> GetByIdAsync(string id)
    {
        var efo = await _payments
                        .Include(p => p.Source)
                        .Include(p => p.Risk)
                        .Include(p => p.Customer)
                        .FirstOrDefaultAsync(w => w.Id.Equals(id));

        return efo?.ToDomainEntity();
    }

    public async Task<PagedResponse<Payment>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        int totalCount = await _payments.AsNoTracking()
                                        .CountAsync();

        var data = await _payments.Include(p => p.Source)
                                  .Include(p => p.Risk)
                                  .Include(p => p.Customer)
                                  .OrderBy(o => o.Id)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .AsNoTracking()
                                  .ToListAsync();

        var payments = data.Select(s => s.ToDomainEntity())
                           .ToList()
                           .AsReadOnly();

        return new PagedResponse<Payment>(pageNumber, pageSize, totalCount, payments);
    }

    public async Task UpdateAsync(Payment entity)
    {
        PaymentEFO efo = entity.ToEFO();

        _dbContext.Entry(efo).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }
}