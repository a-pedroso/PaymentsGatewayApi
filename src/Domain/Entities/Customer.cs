namespace PaymentsGatewayApi.Domain.Entities;
using System;

public record Customer
{
    public Customer(string id)
    {
        Id = id;
    }
    public string Id { get; init; } = $"cus_{Guid.NewGuid():N}";
}
