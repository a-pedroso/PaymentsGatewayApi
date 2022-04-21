namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetAllPayments;

using MediatR;
using PaymentsGatewayApi.Application.Common.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, Result<PagedResponse<PaymentDTO>>>
{
    private readonly IPaymentsRepository _paymentRepository;
    public GetAllPaymentsQueryHandler(IPaymentsRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Result<PagedResponse<PaymentDTO>>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var pagedResponse = await _paymentRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

        PagedResponse<PaymentDTO> response = new(
            pagedResponse.PageNumber,
            pagedResponse.PageSize,
            pagedResponse.TotalCount,
            pagedResponse.Data.Select(s => s.ToDTO()).ToList().AsReadOnly());

        return Result.Ok(response);
    }
}