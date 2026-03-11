using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class CustomerImplemention : ICustomer
{
    private const string messageNotFound = "product id is not found";
    private const string messageAlreadyExists = "product id is already exists";

    public int Create(Customer customer)
    {
        var cust = from c in _customers
                   where c.CustId == customer.CustId
                   select c;
        if (cust != null)
            throw new DalIdAlreadyExistExceptions(messageAlreadyExists);
        _customers?.Add(customer);
        return customer.CustId;

    }
    public Customer? Read(int id)
    {

        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        if (cust == null)

            throw new DalIdNotFoundExceptions(messageNotFound);

        return (Customer?)cust;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        var list = filter != null ?
                   from c in _customers
                   where filter(c)
                   select c
                    : _customers;
        return list.ToList();
    }
    public void Delete(int id)
    {
        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        if (cust == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        _customers?.Remove((Customer)cust);
    }
    public void Update(Customer customer)
    {
        if (Read(customer.CustId) == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        Delete(customer.CustId);
        Create(customer);
    }
}
