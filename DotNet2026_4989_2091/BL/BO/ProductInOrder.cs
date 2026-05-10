
namespace BO;

public class ProductInOrder
{
    public int ProdId {  get; set; }
    public string ProdName { get; set; }
    public double BasePrice { get; set; }
    public int ProdAmount { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public double TotalPrice { get; set; }

}
