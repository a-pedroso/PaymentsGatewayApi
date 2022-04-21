namespace PaymentsGatewayApi.Application.UnitTests.Features.Payments.Queries.GetPaymentById;

using AutoFixture;
using Moq;
using PaymentsGatewayApi.Application.Features.Payments.Queries.GetPaymentById;
using PaymentsGatewayApi.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

public class GetPaymentByIdQueryHandlerTests : MediatorFixture
{
    [Fact]
    public async Task GetPaymentById_HappyPath()
    {
        // Arrange
        Fixture.Register<PaymentCurrency>(() => PaymentCurrency.USD);
        Fixture.Register<PaymentStatus>(() => PaymentStatus.Authorized);
        Fixture.Register<PaymentSourceType>(() => PaymentSourceType.Card);

        var requestMock = Fixture.Create<GetPaymentByIdQuery>();
        var createdPaymentMock = Fixture.Create<Payment>();

        Mock.Get(PaymentsRepositoryMock)
            .Setup(r => r.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(createdPaymentMock);

        // act
        var handler = new GetPaymentByIdQueryHandler(PaymentsRepositoryMock);
        var result = await handler.Handle(requestMock, new System.Threading.CancellationToken());

        // Assert
        Assert.Equal(createdPaymentMock.Id, result.Data.Id);
        Assert.Equal(createdPaymentMock.ActionId, result.Data.ActionId);
        Assert.Equal(createdPaymentMock.Amount, result.Data.Amount);
        Assert.Equal(createdPaymentMock.Approved, result.Data.Approved);
        Assert.Equal(createdPaymentMock.AuthCode, result.Data.AuthCode);
        Assert.Equal(createdPaymentMock.Currency, result.Data.Currency);
        Assert.Equal(createdPaymentMock.Customer.Id, result.Data.Customer.Id);
        Assert.Equal(createdPaymentMock.Eci, result.Data.Eci);
        Assert.Equal(createdPaymentMock.ProcessedOn, result.Data.ProcessedOn);
        Assert.Equal(createdPaymentMock.Reference, result.Data.Reference);
        Assert.Equal(createdPaymentMock.ResponseCode, result.Data.ResponseCode);
        Assert.Equal(createdPaymentMock.ResponseSummary, result.Data.ResponseSummary);
        Assert.Equal(createdPaymentMock.Risk.Flagged, result.Data.Risk.Flagged);
        Assert.Equal(createdPaymentMock.SchemeId, result.Data.SchemeId);
        Assert.Equal(createdPaymentMock.Status, result.Data.Status);
        Assert.Equal(createdPaymentMock.Source.Id, result.Data.Source.Id);
        Assert.Equal(createdPaymentMock.Source.AvsCheck, result.Data.Source.AvsCheck);
        Assert.Equal(createdPaymentMock.Source.Bin, result.Data.Source.Bin);
        Assert.Equal(createdPaymentMock.Source.CardCategory, result.Data.Source.CardCategory);
        Assert.Equal(createdPaymentMock.Source.CardType, result.Data.Source.CardType);
        Assert.Equal(createdPaymentMock.Source.CvvCheck, result.Data.Source.CvvCheck);
        Assert.Equal(createdPaymentMock.Source.ExpiryMonth, result.Data.Source.ExpiryMonth);
        Assert.Equal(createdPaymentMock.Source.ExpiryYear, result.Data.Source.ExpiryYear);
        Assert.Equal(createdPaymentMock.Source.Fingerprint, result.Data.Source.Fingerprint);
        Assert.Equal(createdPaymentMock.Source.Issuer, result.Data.Source.Issuer);
        Assert.Equal(createdPaymentMock.Source.IssuerCountry, result.Data.Source.IssuerCountry);
        Assert.Equal(createdPaymentMock.Source.Last4, result.Data.Source.Last4);
        Assert.Equal(createdPaymentMock.Source.ProductId, result.Data.Source.ProductId);
        Assert.Equal(createdPaymentMock.Source.ProductType, result.Data.Source.ProductType);
        Assert.Equal(createdPaymentMock.Source.Scheme, result.Data.Source.Scheme);
        Assert.Equal(createdPaymentMock.Source.Type, result.Data.Source.Type);
    }
}
