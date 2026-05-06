using DalApi;
using DO;
using System.Diagnostics;
using System.Reflection;
using Tools;
using static Dal.DataSource;
using static Dal.DataSource.Config;

namespace Dal;

internal class ProductImplemention : IProduct
{
    internal static List<int> emptyId = new List<int>();
    private const string messageNotFound = "product id is not found";
<<<<<<< HEAD
    private const string messageAlreadyExists = "product id is already exists";
=======
>>>>>>> main

    public int Create(Product product)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"START create product: Id={product.ProdId}, Name={product.ProdName}, Categoty={product.ProdCategory}, Price ={product.Price}, QuantityInStock ={ product.QuantityInStock}");
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
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"END create product: Id={product.ProdId}");
        return newProduct.ProdId;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"START read product by condition");
        var prod = from p in _products
                   where filter(p)
                   select p;
        Product? product = prod.FirstOrDefault();
        if (product == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"END read product by condition: found customer Id={product.ProdId}");
        return product;
    }

    public Product? Read(int id)
    {
<<<<<<< HEAD
        var prod = from p in _products
                   where p.ProdId == id
                   select p;
        if (prod == null)

            throw new DalIdNotFoundExceptions(messageNotFound);

        return (Product?)prod;
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)/////
=======
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"START read product by id: Id={id}");
        var prod = from p in _products
                   where p.ProdId == id
                   select p;
        Product? product = prod.FirstOrDefault();
        if (product == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"END read product by id: Id={product.ProdId}, Name={product.ProdName}, Categoty={product.ProdCategory}, Price ={product.Price}, QuantityInStock ={product.QuantityInStock}");
        return product;
    }
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
>>>>>>> main
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
<<<<<<< HEAD
        if (prod == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _products?.Remove((Product)prod);
=======
        Product product = prod.FirstOrDefault();
        if (product == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _products?.Remove(product);
>>>>>>> main
        emptyId.Add(id);
    }
    public void Update(Product product)/////מה עם שליפת שאילתה
    {
        int index = _products.FindIndex(p => p.ProdId == product.ProdId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
<<<<<<< HEAD

=======
>>>>>>> main
        }
        _products[index] = product;
    }
}
