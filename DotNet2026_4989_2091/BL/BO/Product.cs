using System.Collections;

namespace BO;

public class Product
{
    public int ProdId { get; set; }
    public string ProdName { get; set; }
    public ProdCategory ProdCategory { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    
    public List<SaleInProduct> Sales { get; set; }
    public override string ToString() => this.ToStringProperty();

}
