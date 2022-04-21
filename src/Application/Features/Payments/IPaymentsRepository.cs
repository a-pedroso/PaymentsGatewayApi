namespace PaymentsGatewayApi.Application.Features.Payments;
using PaymentsGatewayApi.Application.Common.Wrappers;
using PaymentsGatewayApi.Domain.Entities;
using System.Threading.Tasks;

public interface IPaymentsRepository
{
    Task<Payment> GetByIdAsync(string id);
    Task<PagedResponse<Payment>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Payment> AddAsync(Payment entity);
    Task UpdateAsync(Payment entity);
}