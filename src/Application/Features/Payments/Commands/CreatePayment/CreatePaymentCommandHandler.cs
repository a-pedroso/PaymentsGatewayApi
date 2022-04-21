namespace PaymentsGatewayApi.Application.Features.Payments.Commands.CreatePayment;

using MediatR;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using PaymentsGatewayApi.Application.Common.Wrappers;
using PaymentsGatewayApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<PaymentDTO>>
{
    private readonly IPaymentsRepository _paymentsRepository;
    private readonly ICkoBankSimulator _ckoBankSimulator;

    public CreatePaymentCommandHandler(
        IPaymentsRepository paymentsRepository,
        ICkoBankSimulator ckoBankSimulator)
    {
        _paymentsRepository = paymentsRepository;
        _ckoBankSimulator = ckoBankSimulator;
    }

    public async Task<Result<PaymentDTO>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        CkoBankSimulatorResponse bankResponse = _ckoBankSimulator.ProcessCardPayment(request.Amount,
                                                                                     request.Currency,
                                                                                     request.Source.CardNumber,
                                                                                     request.Source.Cvv,
                                                                                     request.Source.ExpiryMonth,
                                                                                     request.Source.ExpiryYear);
        Payment payment = BuildPaymentEntity(request, bankResponse);

        var addedPayment = await _paymentsRepository.AddAsync(payment);

        PaymentDTO dto = addedPayment.ToDTO();

        return bankResponse.Approved
               ? Result.Ok(dto)
               : Result.Fail(dto, GetErrorList(dto));
    }

    private static IEnumerable<string> GetErrorList(PaymentDTO dto)
    {
        List<string> errors = new()
        {
            dto.ResponseSummary
        };
        return errors;
    }

    private static Payment BuildPaymentEntity(CreatePaymentCommand request, CkoBankSimulatorResponse bankResponse)
    {
        return new Payment(
                        id: string.Empty,
                        actionId: string.Empty,
                        request.Amount,
                        (PaymentCurrency)request.Currency,
                        bankResponse.Approved,
                        bankResponse.Approved ? PaymentStatus.Authorized : PaymentStatus.Declined,
                        bankResponse.AuthCode,
                        bankResponse.Eci,
                        bankResponse.SchemeId,
                        bankResponse.ResponseCode,
                        bankResponse.ResponseSummary,
                        new Risk(bankResponse.Flagged),
                        new Source(
                            id: string.Empty,
                            PaymentSourceType.Card,
                            bankResponse.ExpiryMonth,
                            bankResponse.ExpiryYear,
                            bankResponse.Scheme,
                            bankResponse.Last4,
                            bankResponse.Fingerprint,
                            bankResponse.Bin,
                            bankResponse.CardType,
                            bankResponse.CardCategory,
                            bankResponse.Issuer,
                            bankResponse.IssuerCountry,
                            bankResponse.ProductId,
                            bankResponse.ProductType,
                            bankResponse.AvsCheck,
                            bankResponse.CvvCheck),
                        new Customer(id: string.Empty),
                        bankResponse.ProcessedOn,
                        request.Reference);
    }
}