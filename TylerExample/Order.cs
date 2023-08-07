namespace TylerExample;

public class Order
{
    private readonly List<LineItem> _lineItems = new();

    #region Creation

    public Order()
    {
        _lineItems.Add(new());
    }

    #endregion

    #region Implementation

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    #endregion
}

public class LineItem
{
}
