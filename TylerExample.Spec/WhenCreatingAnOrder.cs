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

    #region Requirements

    [Fact]
    public void ThenLineItemsAreExpected()
    {
        var order = new Order(new List<LineItem> { _lineItem });

        order.LineItems.Should().BeEquivalentTo(new List<LineItem> { new("ABC123", 1) });
    }

    [Fact]
    public void ThenOrderHasAtLeastOneLineItem()
    {
        var order = new Order(new List<LineItem> { _lineItem });

        order.LineItems.Should().HaveCountGreaterThan(0);
    }

    #endregion
}
