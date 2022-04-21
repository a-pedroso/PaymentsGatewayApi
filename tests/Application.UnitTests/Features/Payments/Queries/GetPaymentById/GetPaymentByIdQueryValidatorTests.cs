namespace PaymentsGatewayApi.Application.UnitTests.Features.Payments.Queries.GetPaymentById;

using FluentValidation.TestHelper;
using PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;
using Xunit;

public class GetPaymentByIdQueryValidatorTests : MediatorFixture
{
    [Fact]
    public void GetPaymentByIdQueryValidator_HappyPath()
    {
        // Arrange
        var validator = new GetPaymentByIdQueryValidator();
        var qry = new GetPaymentByIdQuery()
        {
            Id = "pay_123"
        };

        // act
        var result = validator.TestValidate<GetPaymentByIdQuery>(qry);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void EmptyId_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new GetPaymentByIdQueryValidator();
        var qry = new GetPaymentByIdQuery()
        {
            Id = null
        };

        // act
        var result = validator.TestValidate<GetPaymentByIdQuery>(qry);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.Id);
    }
}