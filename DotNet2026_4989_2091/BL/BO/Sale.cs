namespace BO;

public class Sale
{
    public int SaleId { get; set; }
    public int ProdId { get; set; }
    public int MinRequireQuantity { get; set; }
    public double PriceInSale { get; set; }
    public bool JustForClub { get; set; }
    public DateTime? StartDateSale { get; set; }
    public DateTime? StopDateSale { get; set; }
}
