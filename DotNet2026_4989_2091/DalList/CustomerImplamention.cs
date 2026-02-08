using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class CustomerImplemention : ICustomer
{
    private const string messageNotFound = "customer id is not found";
    private const string messageAlreadyExists = "customer id is already exists";

    public int Create(Customer customer)
    {
        var cust = from c in _customers
                   where c.CustId == customer.CustId
                   select c;
        if (cust.FirstOrDefault() != null)
            throw new DalIdAlreadyExistExceptions(messageAlreadyExists);
        _customers?.Add(customer);
        return customer.CustId;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        var cust = from c in _customers
                   where filter(c)
                   select c;
        Customer? customer = cust.FirstOrDefault();
        if (customer != null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return customer;
    }

    public Customer? Read(int id)
    {
        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        Customer? customer = cust.FirstOrDefault();
        if (customer == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return customer;
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
        Customer? customer = cust.FirstOrDefault();
        if (customer == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        _customers?.Remove(customer);
    }
    public void Update(Customer customer)
    {
        if (Read(customer.CustId) == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        Delete(customer.CustId);
        Create(customer);
    }

}
