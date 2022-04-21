namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;

using MediatR;
using PaymentsGatewayApi.Application.Common.Exceptions;
using PaymentsGatewayApi.Application.Common.Wrappers;
using PaymentsGatewayApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

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