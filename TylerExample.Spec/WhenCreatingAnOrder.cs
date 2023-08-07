using FluentAssertions;

namespace TylerExample.Spec;

public class WhenCreatingAnOrder
{
    #region Requirements

    [Fact]
    public void ThenOrderHasAtLeastOneLineItem()
    {
        var order = new Order();

        order.LineItems.Should().HaveCountGreaterThan(0);
    }

    #endregion
}
