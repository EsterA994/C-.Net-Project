using BlApi;
using static BO.Tools;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private readonly DalApi.IDal _dal = DalApi.Factory.Get;

    public List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int prodId, int amount)
    {
        var doProduct = _dal.Product.Read(prodId);

        if (doProduct == null)
            throw new BO.BlDoesNotExistException("Product does not exist");

        BO.Product product = doProduct.ToBO();
        BO.ProductInOrder productInOrder = order.ProductsList
            .FirstOrDefault(p => p.ProdId == prodId);

        if (productInOrder == null)
        {
            if (amount > product.QuantityInStock)
                throw new BO.BlOutOfStock("Out of stock");

            productInOrder = new BO.ProductInOrder
            {
                ProdId = product.ProdId,
                ProdName = product.ProdName,
                BasePrice = product.Price,
                ProdAmount = amount,
                Sales = new List<BO.SaleInProduct>()
            };

            order.ProductsList.Add(productInOrder);
        }
        else
        {
            if (productInOrder.ProdAmount + amount > product.QuantityInStock)
                throw new BO.BlOutOfStock("Out of stock");

            productInOrder.ProdAmount += amount;

            if (productInOrder.ProdAmount <= 0)
            {
                order.ProductsList.Remove(productInOrder);
                CalcTotalPrice(order);
                return new List<BO.SaleInProduct>();
            }
        }

        SearchSaleForProduct(productInOrder, order.IsPreferredCust);
        CalcTotalPriceForProduct(productInOrder);
        CalcTotalPrice(order);

        return productInOrder.Sales;
    }

    public void CalcTotalPrice(BO.Order order)
    {
        order.FinalPrice = order.ProductsList?.Sum(s => s.TotalPrice) ?? 0;
    }

    public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
    {
        int count = productInOrder.ProdAmount;

        double total = 0;
        List<BO.SaleInProduct> usedSales = new List<BO.SaleInProduct>();

        foreach (BO.SaleInProduct sale in productInOrder.Sales)
        {
            if (count < sale.AmountForSale)
                continue;

            int numOfSales = count / sale.AmountForSale;
            total += numOfSales * sale.Price;
            count -= numOfSales * sale.AmountForSale;

            usedSales.Add(sale);

            if (count == 0)
                break;
        }

        total += count * productInOrder.BasePrice;

        productInOrder.TotalPrice = total;

        productInOrder.Sales = usedSales;
    }

    public void DoOrder(BO.Order order)
    {
        foreach (BO.ProductInOrder item in order.ProductsList)
        {
            var doProduct = _dal.Product.Read(item.ProdId);
            if (doProduct == null)
                throw new BO.BlDoesNotExistException("Product does not exist");

            BO.Product product = doProduct.ToBO();

            if (item.ProdAmount > product.QuantityInStock)
                throw new BO.BlOutOfStock("Not enough stock");

            product.QuantityInStock -= item.ProdAmount;

            _dal.Product.Update(product.ToDO());
        }
    }

    public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isClubMember)
    {
        DateTime now = DateTime.Now;

        productInOrder.Sales = _dal.Sale.ReadAll(s =>
                s.ProdId == productInOrder.ProdId &&
                s.StartDateSale != null &&
                s.StopDateSale != null &&
                s.StartDateSale <= now &&
                s.StopDateSale >= now &&
                productInOrder.ProdAmount >= s.MinRequireQuantity &&
                (!s.JustForClub || isClubMember)
            )
            .OrderBy(s => s.PriceInSale)
            .Select(s => s.ToSaleInProduct())
            .ToList();
    }
}
