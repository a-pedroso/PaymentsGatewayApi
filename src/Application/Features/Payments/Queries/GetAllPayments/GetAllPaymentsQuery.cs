namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetAllPayments;

using MediatR;
using PaymentsGatewayApi.Application.Common.Wrappers;

public class GetAllPaymentsQuery : PagedRequest, IRequest<Result<PagedResponse<PaymentDTO>>>
{
}