using DalApi;

namespace Dal;
public class DalList : IDal
{
    public IProduct Product => new ProductImplemention();

    public ISale Sale => new SaleImplamention();

    public ICustomer Customer => new CustomerImplemention();
}

