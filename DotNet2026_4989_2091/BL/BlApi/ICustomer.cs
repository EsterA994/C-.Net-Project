using BO;

namespace BlApi;

public interface ICustomer
{
    public int Create(Customer item);
    public Customer? Read(Func<Customer, bool> filter);
    public Customer? Read(int id);
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null);
    public void Delete(int id);
    public void Update(Customer item);
    public bool IsExsitsCust(int id);
}
