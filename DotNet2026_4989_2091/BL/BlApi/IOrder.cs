using BO;

namespace BlApi;

public interface IOrder
{
    public List<SaleInProduct> AddProductToOrder(Order order, int prodId, int amount);
    public void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    public void CalcTotalPrice(Order order);
    public void DoOrder(Order order);
    public void SearchSaleForProduct(ProductInOrder productInOrder, bool isClubMember);
}