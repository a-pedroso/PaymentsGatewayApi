namespace PaymentsGatewayApi.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

public record PaymentSourceType
{
    public static readonly PaymentSourceType Card = new(1, nameof(Card));
    public static readonly PaymentSourceType Token = new(2, nameof(Token));

    private readonly int _id;
    private readonly string _name;

    private PaymentSourceType(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public static IEnumerable<PaymentSourceType> List() =>
        new[] { Card, Token };

    public override string ToString() => _name;

    public static implicit operator string(PaymentSourceType paymentSourceType) => paymentSourceType._name;
    public static explicit operator PaymentSourceType(string str) => List().SingleOrDefault(s => string.Equals(s._name, str, StringComparison.CurrentCultureIgnoreCase));
}