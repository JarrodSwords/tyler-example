namespace TylerExample;

public class Order
{
    private readonly List<LineItem> _lineItems = new();

    #region Creation

    public Order(IEnumerable<LineItem> lineItems)
    {
        _lineItems.AddRange(lineItems.OrderByDescending(x => x.Quantity));
    }

    #endregion

    #region Implementation

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    #endregion
}
