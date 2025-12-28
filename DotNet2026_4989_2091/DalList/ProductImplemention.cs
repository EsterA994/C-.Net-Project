using DO;
using DalApi;
//using static Dal.DataSource;

namespace Dal;

public class ProductImplemention : IProduct
{
    internal static List<int> emptyId = new List<int> { };

    public int Create(Product product)
    {
        if (product == null)
            return 0;
        if (emptyId.length > 0)
        {
            Product newProduct = product with { ProdId = emptyId[0] };
            emptyId.remove(emptyId[0]);
            _products.Add(newProduct);
        }
        else
        {
            //לשנות למזהה רץ
            Product newProduct = product with { ProdId = 1 };
        }

        return 0;
    }
    public Product Read(int id)
    {
        if (!_products.contains(ProdId = id))
        {
            throw new Exception("");
        }
        else { return _products.find(ProdId = id); }
    }
    public List<Product> ReadAll()
    {
        return _products;
    }
    public void Delete(int id)
    {
        if (_products.contain(ProdId = id))
        {
            _products.remove(ProdId = id);
            emptyId.add(id);
        }
    }
    public void Update(Product product)
    {
        int index = _products.indexOf(prodID = product.ProdId);
        if (index != -1)
        {
            _products[index] = product;
        }
    }
}
