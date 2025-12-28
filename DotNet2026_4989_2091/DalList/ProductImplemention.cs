using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class ProductImplemention : IProduct
{
    internal static List<int> emptyId = new List<int>();

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
            //לשנות למזהה רץ
            newProduct = product with { ProdId = 1 };
        }
        _products?.Add(newProduct);

        return newProduct.ProdId;
    }
    public Product? Read(int id)
    {
        if (_products?.Any(p => p.ProdId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        return _products?.Find(p => p.ProdId == id);

    }
    public List<Product> ReadAll()
    {
        return _products;
    }
    public void Delete(int id)
    {
        if (_products?.Any(p => p.ProdId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        _products?.RemoveAll(p => p.ProdId == id);
        emptyId.Add(id);
    }
    public void Update(Product product)
    {
        int index = _products.FindIndex(p => p.ProdId == product.ProdId);
        if (index == -1)
        {
            throw new IdNotFoundExceptions();

        }
        _products[index] = product;
    }
}
