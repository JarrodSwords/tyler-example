namespace TylerExample;

public class Order
{
    private List<LineItem> _lineItems = new();

    #region Creation

    public Order(params LineItem[] lineItems)
    {
        _lineItems.AddRange(lineItems.OrderByDescending(x => x));
    }

    #endregion

    #region Implementation

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public void Add(LineItem lineItem)
    {
        _lineItems.Add(lineItem);
        _lineItems = _lineItems.OrderByDescending(x => x).ToList();
    }

    #endregion
}
