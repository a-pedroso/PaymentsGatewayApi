namespace PaymentsGatewayApi.Domain.Common;

using System;

public abstract record BaseEntity<TKey> where TKey : IEquatable<TKey>
{
    public abstract TKey Id { get; init; }
}
