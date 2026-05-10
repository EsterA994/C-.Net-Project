using DalApi;

namespace Dal;

public class DalXml : IDal
{
    IProduct Product = new ProductIImplementation();
    IProduct Customer = new CustomerIImplementation();
    IProduct Product = new ProductIImplementation();
}
