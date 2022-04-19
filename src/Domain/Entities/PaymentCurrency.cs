namespace PaymentsGatewayApi.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

public record PaymentCurrency
{
    public static readonly PaymentCurrency USD = new(1, nameof(USD));
    public static readonly PaymentCurrency EUR = new(2, nameof(EUR));

    private readonly int _id;
    private readonly string _name;

    private PaymentCurrency(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public static IEnumerable<PaymentCurrency> List() =>
        new[] { USD, EUR };

    public override string ToString() => _name;

    public static implicit operator string(PaymentCurrency paymentCurrency) => paymentCurrency._name;
    public static explicit operator PaymentCurrency(string str) => List().SingleOrDefault(s => string.Equals(s._name, str, StringComparison.CurrentCultureIgnoreCase));
}
