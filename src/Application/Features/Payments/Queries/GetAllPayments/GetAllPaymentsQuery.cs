namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetAllPayments;

using PaymentsGatewayApi.Application.Common.Wrappers;
using MediatR;

public class GetAllPaymentsQuery : PagedRequest, IRequest<Result<PagedResponse<PaymentDTO>>>
{
}
