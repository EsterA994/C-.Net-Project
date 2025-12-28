using DO;
using DalApi;
using static Dal.DataSource;

namespace Dal;

internal class CustomerImplemention : ICustomer
{
    public int Create(Customer customer)
    {
        if (_customers?.Any(c => c.CustId == customer.CustId) == null)
        {
            throw new IdAlreadyExistExceptions();
        }
        _customers?.Add(customer);
        return customer.CustId;
    }
    public Customer? Read(int id)
    {
        if (_customers?.Any(c => c.CustId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        return _customers?.Find(c => c.CustId == id);

    }
    public List<Customer> ReadAll()
    {
        return _customers;
    }
    public void Delete(int id)
    {
        if (_customers?.Any(c => c.CustId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        _customers?.RemoveAll(c => c.CustId == id);
    }
    public void Update(Customer customer)
    {
        int index = _customers.FindIndex(c => c.CustId == customer.CustId);
        if (index == -1)
        {
            throw new IdNotFoundExceptions();

        }
        _customers[index] = customer;
    }
}
