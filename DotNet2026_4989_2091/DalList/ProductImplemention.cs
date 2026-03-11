using DO;
using DalApi;
using static Dal.DataSource;
using static Dal.DataSource.Config;

namespace Dal;

internal class ProductImplemention : IProduct
{
    internal static List<int> emptyId = new List<int>();
    private const string messageNotFound = "product id is not found";
    private const string messageAlreadyExists = "product id is already exists";

    public int Create(Product product)
    {
        Product newProduct;
        if (emptyId.Count > 0)
        {
            newProduct = product with { ProdId = emptyId[0] };
            emptyId.Remove(emptyId[0]);
        }
        else
        {
            newProduct = product with { ProdId = CurProductId };
        }
        _products?.Add(newProduct);

        return newProduct.ProdId;
    }
    public Product? Read(int id)
    {
        var prod = from p in _products
                   where p.ProdId == id
                   select p;
        if (prod == null)

            throw new DalIdNotFoundExceptions(messageNotFound);

        return (Product?)prod;
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)/////
    {
        var list = filter != null ?
                   from p in _products
                   where filter(p)
                   select p
                   : _products;
        return list.ToList();
    }
    public void Delete(int id)
    {
        var prod = from p in _products
                   where p.ProdId == id
                   select p;
        if (prod == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _products?.Remove((Product)prod);
        emptyId.Add(id);
    }
    public void Update(Product product)/////מה עם שליפת שאילתה
    {
        int index = _products.FindIndex(p => p.ProdId == product.ProdId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);

        }
        _products[index] = product;
    }
}
