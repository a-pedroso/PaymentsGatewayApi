namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;

using PaymentsGatewayApi.Application.Common.Exceptions;
using PaymentsGatewayApi.Application.Common.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PaymentsGatewayApi.Domain.Entities;

public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Result<PaymentDTO>>
{
    private readonly IPaymentsRepository _paymentRepository;

    public GetPaymentByIdQueryHandler(
        IPaymentsRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Result<PaymentDTO>> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
    {
        Payment payment = await _paymentRepository.GetByIdAsync(query.Id);
        if (payment == null)
        {
            throw new NotFoundException(nameof(payment), query.Id);
        }

        return Result.Ok(payment.ToDTO());
    }
}
