namespace PaymentsGatewayApi.Application.UnitTests.Features.Payments.Commands.CreatePayment;

using AutoFixture;
using FluentValidation.TestHelper;
using PaymentsGatewayApi.Application.Features.Payments.Commands.CreatePayment;
using Xunit;

public class CreatePaymentCommandValidatorTests : MediatorFixture
{
    [Fact]
    public void CreatePaymentCommandValidator_HappyPath()
    {
        // Arrange
        var validator = new CreatePaymentCommandValidator();
        var cmd = new CreatePaymentCommand()
        {
            Amount = 100,
            Currency = "USD",
            Reference = "REF_TEST",
            Metadata = Fixture.Create<CreatePaymentCommandMetadata>(),
            Source = new CreatePaymentCommandSource(
                "Card",
                string.Empty,
                12,
                2030,
                1234567890123456,
                123)
        };

        // act
        var result = validator.TestValidate<CreatePaymentCommand>(cmd);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void InvalidAmount_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new CreatePaymentCommandValidator();
        var cmd = new CreatePaymentCommand()
        {
            Amount = -1,
            Currency = "USD",
            Reference = "REF_TEST",
            Metadata = Fixture.Create<CreatePaymentCommandMetadata>(),
            Source = new CreatePaymentCommandSource(
                "Card",
                string.Empty,
                12,
                2030,
                1234567890123456,
                123)
        };

        // act
        var result = validator.TestValidate<CreatePaymentCommand>(cmd);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.Amount);
    }

    [Fact]
    public void EmptyReference_ShouldHaveValidationError()
    {
        // Arrange
        var validator = new CreatePaymentCommandValidator();
        var cmd = new CreatePaymentCommand()
        {
            Amount = 100,
            Currency = "USD",
            Reference = null,
            Metadata = Fixture.Create<CreatePaymentCommandMetadata>(),
            Source = new CreatePaymentCommandSource(
                "Card",
                string.Empty,
                12,
                2030,
                1234567890123456,
                123)
        };

        // act
        var result = validator.TestValidate<CreatePaymentCommand>(cmd);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.Reference);
    }

    //TODO: add all tests for all validations
}