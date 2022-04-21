namespace PaymentsGatewayApi.Application.UnitTests;

using AutoFixture;
using Moq;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using PaymentsGatewayApi.Application.Features.Payments;
using PaymentsGatewayApi.Domain.Entities;

public class MediatorFixture
{
    protected readonly IFixture Fixture;

    // Repository mocks
    protected readonly IPaymentsRepository PaymentsRepositoryMock = Mock.Of<IPaymentsRepository>();

    // Services Mock
    protected readonly ICkoBankSimulator CkoBankSimulatorMock = Mock.Of<ICkoBankSimulator>();

    protected MediatorFixture()
    {
        Fixture = new Fixture();

        // Domain Fixtures
        //Fixture.Register<PaymentCurrency>(() => PaymentCurrency.USD);
        //Fixture.Register<PaymentStatus>(() => PaymentStatus.Authorized);
        //Fixture.Register<PaymentSourceType>(() => PaymentSourceType.Card);
    }
}
