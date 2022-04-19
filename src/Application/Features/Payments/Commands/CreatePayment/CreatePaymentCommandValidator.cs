namespace PaymentsGatewayApi.Application.Features.Payments.Commands.CreatePayment;

using FluentValidation;
using PaymentsGatewayApi.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(r => r.Amount)
            .GreaterThan(0)
                .WithMessage("{PropertyName} as to be greater then zero");

        RuleFor(r => r.Currency)
            .NotEmpty()
                .WithMessage("{PropertyName} is required.")
            .MustAsync(IsValidCurrency)
                .WithMessage("{PropertyName} invalid value.");

        RuleFor(r => r.Reference)
            .NotEmpty()
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Metadata)
            .NotNull()
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Metadata.CouponCode)
            .NotEmpty()
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Metadata.PartnerId)
            .GreaterThan(0)
                .WithMessage("{PropertyName} has to be greater then zero")
            .MustAsync(IsValidPartnerId)
                .WithMessage("{PropertyName} invalid partner.");

        RuleFor(r => r.Metadata.Udf1)
            .NotEmpty()
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Source)
            .NotNull()
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Source.Type)
            .NotEmpty()
                .WithMessage("{PropertyName} is required.")
            .MustAsync(IsValidSourceType)
                .WithMessage("{PropertyName} invalid value.");

        RuleFor(r => r.Source.Token)
            .NotEmpty()
            .When(r => r.Source.Type.Equals(PaymentSourceType.Token.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("{PropertyName} is required.");

        RuleFor(r => r.Source.CardNumber)
            .MustAsync(IsValidCardNumber)
            .When(r => r.Source.Type.Equals(PaymentSourceType.Card.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("{PropertyName} is invalid.");

        RuleFor(r => r.Source.Cvv)
            .InclusiveBetween(100, 999)
            .When(r => r.Source.Type.Equals(PaymentSourceType.Card.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("{PropertyName} is required. valid values between 100 and 999");

        RuleFor(r => r.Source.ExpiryMonth)
            .InclusiveBetween(1, 12)
            .When(r => r.Source.Type.Equals(PaymentSourceType.Card.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("{PropertyName} is required. Valid value between 1 and 12");

        RuleFor(r => r.Source.ExpiryYear)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Year)
            .When(r => r.Source.Type.Equals(PaymentSourceType.Card.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .WithMessage("{PropertyName} is required. Valid value Greater or equal of current year");
    }

    private async Task<bool> IsValidCurrency(string currency, CancellationToken cancellationToken)
    {
        //TODO: validation 
        return await Task.FromResult(true);
    }

    private async Task<bool> IsValidPartnerId(int partnerId, CancellationToken cancellationToken)
    {
        //TODO: validation -> access partner service to validate if the partner is active
        return await Task.FromResult(true);
    }

    private async Task<bool> IsValidSourceType(string sourceType, CancellationToken cancellationToken)
    {
        //TODO: validation 
        return await Task.FromResult(true);
    }

    private async Task<bool> IsValidCardNumber(long cardNumber, CancellationToken cancellationToken)
    {
        //TODO: validation 
        return await Task.FromResult(true);
    }
}
