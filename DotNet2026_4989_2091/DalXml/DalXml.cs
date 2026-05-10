using DalApi;

namespace Dal;

internal sealed class DalXml : IDal
{
    private DalXml instance = new DalXml();

    public DalXml Instance
    {
        get { return instance = new DalXml(); }
    }    

    private DalXml()
    {
        instance = new DalXml();
    }

    public IProduct Product => new ProductImplementation();
    public ISale Sale => new SaleImplementation();
    public ICustomer Customer => new CustomerImplementation();
}
