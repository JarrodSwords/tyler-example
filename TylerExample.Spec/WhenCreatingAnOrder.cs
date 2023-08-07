using FluentAssertions;

namespace TylerExample.Spec;

public class WhenCreatingAnOrder
{
    #region Setup

    private readonly LineItem _lineItem;

    public WhenCreatingAnOrder()
    {
        _lineItem = new("ABC123", 1);
    }

    #endregion

    #region Implementation

    public static IEnumerable<object[]> GetOutOfOrderLineItems()
    {
        yield return new object[] { new LineItem("XYZ123", 1), new LineItem("ABC123", 2) };
        yield return new object[] { new LineItem("XYZ123", 1), new LineItem("ABC123", 5), new LineItem("MNO345", 3) };
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenLineItemsAreExpected()
    {
        var order = new Order(_lineItem);

        order.LineItems.Should().BeEquivalentTo(new List<LineItem> { new("ABC123", 1) });
    }

    [Theory]
    [MemberData(nameof(GetOutOfOrderLineItems))]
    public void ThenLineItemsAreSortedInDescendingOrderByQuantity(params LineItem[] lineItems)
    {
        var order = new Order(lineItems);

        order.LineItems.Should().BeInDescendingOrder(x => x.Quantity);
    }

    [Fact]
    public void ThenOrderHasAtLeastOneLineItem()
    {
        var order = new Order(_lineItem);

        order.LineItems.Should().HaveCountGreaterThan(0);
    }

    #endregion
}

public class WhenAddingALineItem
{
    #region Requirements

    [Fact]
    public void ThenOrderIsPreserved()
    {
        var order = new Order(
            new LineItem("ABC123", 1),
            new LineItem("ABC123", 2),
            new LineItem("ABC123", 4),
            new LineItem("ABC123", 5)
        );

        order.Add(new("ABC123", 3));

        order.LineItems.Should().BeInDescendingOrder(x => x.Quantity);
    }

    #endregion
}
