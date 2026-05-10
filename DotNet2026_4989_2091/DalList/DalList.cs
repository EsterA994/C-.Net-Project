using DalApi;

namespace Dal;
public class DalList : IDal
{
    public IProduct Product => new ProductIImplementationation();

    public ISale Sale => new SaleIImplementationation();

    public ICustomer Customer => new CustomerIImplementationion();
}

