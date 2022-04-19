namespace PaymentsGatewayApi.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Authorized, Captured, Card Verified, Declined, and Pending
/// from: https://www.checkout.com/docs/payments/accept-payments/request-a-card-payment#Response_example
/// </summary>
public class PaymentStatus
{
    public static readonly PaymentStatus Authorized = new(1, nameof(Authorized));
    public static readonly PaymentStatus Captured = new(2, nameof(Captured));
    public static readonly PaymentStatus CardVerified = new(3, nameof(CardVerified));
    public static readonly PaymentStatus Declined = new(4, nameof(Declined));
    public static readonly PaymentStatus Pending = new(5, nameof(Pending));

    private readonly int _id;
    private readonly string _name;

    private PaymentStatus(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public static IEnumerable<PaymentStatus> List() =>
        new[] { Authorized, Captured, CardVerified, Declined, Pending };

    public override string ToString() => _name;

    public static implicit operator string(PaymentStatus paymentStatus) => paymentStatus._name;
    public static explicit operator PaymentStatus(string str) => List().SingleOrDefault(s => string.Equals(s._name, str, StringComparison.CurrentCultureIgnoreCase));
}