using DalApi;
using DO;
using System.Xml.Linq;

namespace DalXml;

internal class ProductImplement : IProduct
{
    XElement productXml;

    const string prodPath = @"../xml/products.xml";

    const string PROD_ID = "ProdId";
    const string PROD_NAME = "ProdName";
    const string PROD_CATEGORY = "ProdCategory";
    const string PRICE = "Price";
    const string QUANTITY_IN_STOCK = "QuantityInStock";
    const string ARRAY_OF_PRODUCT = "ArrayOfProduct";
    const string PRODUCT = "Product";


    public int Create(Product item)
    {
        Product newProduct = item with { ProdId = Config.ProductNum };

        productXml = XElement.Load(prodPath);

        productXml.Element(ARRAY_OF_PRODUCT)
            .Add(new XElement(PRODUCT,
            new XElement(PROD_ID, newProduct.ProdId),
            new XElement(PROD_NAME, newProduct.ProdName),
            new XElement(PROD_CATEGORY, newProduct.ProdCategory),
            new XElement(PRICE, newProduct.Price),
            new XElement(QUANTITY_IN_STOCK, newProduct.QuantityInStock)
          ));

        productXml.Save(prodPath);

        return newProduct.ProdId;
    }

    public void Delete(int id)
    {
        productXml = XElement.Load(prodPath);

        productXml.Descendants(PROD_ID)
            .FirstOrDefault(pId => id == pId.Value)
            .Parent.Remove(prodPath);

        productXml.Save(prodPath);
    }

    public Product? Read(Func<Product, bool> filter)
    {
        throw new NotImplementedException();//
    }

    public Product? Read(int id)
    {
        productXml = XElement.Load(prodPath);

        Product product = productXml.Descendants(PRODUCT)
            .FirstOrDefault(pId=>pId.Value == id)
            .Parent();

        if (product == null)
            throw new NotImplementedException();//

        return (Product)product;
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Product item)
    {
        throw new NotImplementedException();
    }
}
