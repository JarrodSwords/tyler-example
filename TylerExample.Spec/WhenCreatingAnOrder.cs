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
        yield return new object[] { new List<LineItem> { new("XYZ123", 1), new("ABC123", 2) } };
        yield return new object[] { new List<LineItem> { new("XYZ123", 1), new("ABC123", 5), new("MNO345", 3) } };
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenLineItemsAreExpected()
    {
        var order = new Order(new List<LineItem> { _lineItem });

        order.LineItems.Should().BeEquivalentTo(new List<LineItem> { new("ABC123", 1) });
    }

    [Theory]
    [MemberData(nameof(GetOutOfOrderLineItems))]
    public void ThenLineItemsAreSortedInDescendingOrderByQuantity(IEnumerable<LineItem> lineItems)
    {
        var order = new Order(lineItems);

        order.LineItems.Should().BeInDescendingOrder(x => x.Quantity);
    }

    [Fact]
    public void ThenOrderHasAtLeastOneLineItem()
    {
        var order = new Order(new List<LineItem> { _lineItem });

        order.LineItems.Should().HaveCountGreaterThan(0);
    }

    #endregion
}
