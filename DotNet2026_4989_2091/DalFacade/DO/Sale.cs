namespace DO;

public record Sale(
    int SaleId,
    int ProdId,
    int MinRequireQuantity,
    double PriceInSale,
    bool JustForClub,
    DateTime? StartDateSale,
    DateTime? StopDateSale
    )
{
    public Sale() : this(0, 0, 1, 0, false, DateTime.Now, DateTime.Now) { }
}
