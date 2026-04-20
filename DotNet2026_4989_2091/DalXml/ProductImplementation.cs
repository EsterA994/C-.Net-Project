using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal
{
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
            Product newProduct = item with { ProdId = ProductNum };

            productXml = XElement.Load(prodPath);

            productXml.Element(ARRAY_OF_PRODUCT)
                .Add(new XElement(PRODUCT,
                new XElement(PROD_ID, item.ProdId),
                new XElement(PROD_NAME, item.ProdName),
                new XElement(PROD_CATEGORY, item.ProdCategory),
                new XElement(PRICE, item.Price),
                new XElement(QUANTITY_IN_STOCK, item.QuantityInStock)
              ));

            productXml.Save(prodPath);

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product? Read(Func<Product, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Product? Read(int id)
        {
            throw new NotImplementedException();
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
}
