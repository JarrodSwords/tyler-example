namespace TylerExample;

public record LineItem(string Sku, byte Quantity) : IComparable<LineItem>
{
    #region IComparable<LineItem> Implementation

    public int CompareTo(LineItem? other)
    {
        if (ReferenceEquals(this, other))
            return 0;
        if (ReferenceEquals(null, other))
            return 1;
        return Quantity.CompareTo(other.Quantity);
    }

    #endregion
}
