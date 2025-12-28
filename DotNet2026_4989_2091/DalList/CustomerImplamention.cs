using DO;
using DalApi;

namespace Dal;
    public class CustomerImplamention : ICustomer
{
    public int Create(Customer customer)
    {
        if (_customers.contains(CustId == customer.CustId))
        {
            throw new IdAlreadyExistExceptions();
        }
        else
        {
            _customers.Add(customer);
        }
        return customer.CustId;
    }
    public Custmer? Read(int id)
    {
        if (!_customers.contains(CustId = id))
        {
            throw new IdNotFoundExceptions();
        }
        else
        {
            return _customers.find(CustId = id);
        }
    }
    public List<Customer> ReadAll()
    {
        return _customers;
    }
    public void Delete(int id)
    {
        if (!_customers.contains(CustId = id))
        {
            throw new IdNotFoundExceptions();
        }
        else
        {
            _customers.remove(CustId = id);
            emptyId.add(id);
        }
    }
    public void Update(Customer customer)
    {
        int index = _customers.indexOf(CustId = customer.CustId);
        if (index == -1)
        {
            throw new IdNotFoundExceptions();

        }
        else
        {
            _customers[index] = customer;
        }
    }
}
