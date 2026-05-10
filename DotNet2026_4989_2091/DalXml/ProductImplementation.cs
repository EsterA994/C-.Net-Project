using DalApi;
using DO;
using System.Xml.Linq;
using DalXml;

namespace Dal;

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

    private const string messageNotFound = "product not found";

    public int Create(Product item)
    {
        productXml = XElement.Load(prodPath);

        Product newProduct = item with { ProdId = Config.ProductNum };

        productXml.Add(ToXElement(newProduct));
        productXml.Save(prodPath);

        return newProduct.ProdId;
    }

    public void Delete(int id)
    {
        productXml = XElement.Load(prodPath);

        XElement? productElement = productXml
            .Elements(PRODUCT)
            .FirstOrDefault(p =>
                int.Parse(p.Element(PROD_ID)!.Value) == id);

        if (productElement == null)
            throw new DalIdNotFoundExceptions(messageNotFound);

        productElement.Remove();

        productXml.Save(prodPath);
    }

    public Product? Read(Func<Product, bool> filter)
    {
        productXml = XElement.Load(prodPath);

        return productXml
        .Elements(PRODUCT)
        .Select(ToProduct)
        .FirstOrDefault(filter);
    }

    public Product? Read(int id)
    {
        productXml = XElement.Load(prodPath);

        XElement? productElement = productXml
            .Elements(PRODUCT)
            .FirstOrDefault(p =>
                int.Parse(p.Element(PROD_ID)!.Value) == id);

        if (productElement == null)
            throw new DalIdNotFoundExceptions(messageNotFound);

        return ToProduct(productElement);
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        productXml = XElement.Load(prodPath);

        var products = productXml.Elements(PRODUCT)
                             .Select(p => ToProduct(p));

        if (filter != null)
        {
            products = products.Where(filter);
        }

        return products.ToList();

    }

    public void Update(Product item)
    {
        productXml = XElement.Load(prodPath);

        XElement? productElement = productXml
            .Descendants(PRODUCT)
            .FirstOrDefault(p =>
                int.Parse(p.Element(PROD_ID)!.Value) == item.ProdId);

        if (productElement == null)
            throw new DalIdNotFoundExceptions(messageNotFound);

        productElement.Element(PROD_NAME)?.SetValue(item.ProdName);
        productElement.Element(PRICE)?.SetValue(item.Price);
        productElement.Element(PROD_CATEGORY)?.SetValue(item.ProdCategory);
        productElement.Element(QUANTITY_IN_STOCK)?.SetValue(item.QuantityInStock);
        productXml.Save(prodPath);
    }

    private Product ToProduct(XElement e)
    {
        return new Product
        {
            ProdId = int.Parse(e.Element(PROD_ID)!.Value),
            ProdName = e.Element(PROD_NAME)!.Value,
            Price = double.Parse(e.Element(PRICE)!.Value),
            QuantityInStock = int.Parse(e.Element(QUANTITY_IN_STOCK)!.Value),
            ProdCategory = Enum.Parse<ProdCategory>(
                e.Element(PROD_CATEGORY)!.Value)
        };
    }

    private XElement ToXElement(Product p)
    {
        return new XElement(PRODUCT,
            new XElement(PROD_ID, p.ProdId),
            new XElement(PROD_NAME, p.ProdName),
            new XElement(PROD_CATEGORY, p.ProdCategory),
            new XElement(PRICE, p.Price),
            new XElement(QUANTITY_IN_STOCK, p.QuantityInStock)
        );
    }

}
