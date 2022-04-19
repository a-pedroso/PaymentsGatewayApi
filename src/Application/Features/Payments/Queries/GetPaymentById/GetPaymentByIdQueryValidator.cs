namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;

using FluentValidation;

public class GetPaymentByIdQueryValidator : AbstractValidator<GetPaymentByIdQuery>
{
    public GetPaymentByIdQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
                .WithMessage("{PropertyName} can not be empty.");
    }
}
