namespace PaymentsGatewayApi.Application.Features.Payments.Queries.GetAllPayments;

using FluentValidation;

public class GetAllPaymentsQueryValidator : AbstractValidator<GetAllPaymentsQuery>
{
    public GetAllPaymentsQueryValidator()
    {
        RuleFor(p => p.PageNumber)
            .GreaterThan(0)
                .WithMessage("{PropertyName} has to be greater than zero.");

        RuleFor(p => p.PageSize)
            .GreaterThan(0)
                .WithMessage("{PropertyName} has to be greater than zero.");
    }
}