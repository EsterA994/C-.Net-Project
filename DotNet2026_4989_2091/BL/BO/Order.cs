
using System.Collections;

namespace BO;

public class Order
{
   public bool IsPreferredCust {  get; set; }
    public List<ProductInOrder> ProductsList { get; set; }
    public double FinalPrice { get; set; }
}
