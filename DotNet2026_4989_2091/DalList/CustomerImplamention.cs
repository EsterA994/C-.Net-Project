using DO;
using DalApi;
using static Dal.DataSource;
using System.Reflection;
using Tools;

namespace Dal;

internal class CustomerImplemention : ICustomer
{
<<<<<<< HEAD
    private const string messageNotFound = "product id is not found";
    private const string messageAlreadyExists = "product id is already exists";

    public int Create(Customer customer)
    {
        var cust = from c in _customers
                   where c.CustId == customer.CustId
                   select c;
        if (cust != null)
=======
    private const string messageNotFound = "customer id is not found";
    private const string messageAlreadyExists = "customer id is already exists";

    public int Create(Customer customer)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"START create customer: Id={customer.CustId}, Name={customer.CustName}, Address={customer.CustAddress}");
        var cust = from c in _customers
                   where c.CustId == customer.CustId
                   select c;
        if (cust.FirstOrDefault() != null)
>>>>>>> main
            throw new DalIdAlreadyExistExceptions(messageAlreadyExists);
        _customers?.Add(customer);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"END create customer: Id={customer.CustId}");
        return customer.CustId;

    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
            MethodBase.GetCurrentMethod().Name, $"START read customer by condition");
        var cust = from c in _customers
                   where filter(c)
                   select c;
        Customer? customer = cust.FirstOrDefault();
        if (customer != null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"END read customer by condition: found customer Id={customer.CustId}");
        return customer;
    }

    public Customer? Read(int id)
    {
<<<<<<< HEAD

        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        if (cust == null)

            throw new DalIdNotFoundExceptions(messageNotFound);

        return (Customer?)cust;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
=======
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"START read customer by id: Id={id}");
        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        Customer? customer = cust.FirstOrDefault();
        if (customer == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"END read customer by id: Id={customer.CustId}, Name={customer.CustName}");
        return customer;
    }
    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"START read all customers");
>>>>>>> main
        var list = filter != null ?
                   from c in _customers
                   where filter(c)
                   select c
                    : _customers;
<<<<<<< HEAD
=======
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"END read all customers: count={list?.ToList().Count}");
>>>>>>> main
        return list.ToList();
    }

    public void Delete(int id)
    {
<<<<<<< HEAD
        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        if (cust == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        _customers?.Remove((Customer)cust);
    }
    public void Update(Customer customer)
    {
=======
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"START delete customer: Id={id}");
        var cust = from c in _customers
                   where c.CustId == id
                   select c;
        Customer? customer = cust.FirstOrDefault();
        if (customer == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"END delete customer id: {id}");
        _customers?.Remove(customer);
    }
    public void Update(Customer customer)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"START update customer: Id={customer.CustId}");
>>>>>>> main
        if (Read(customer.CustId) == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        Delete(customer.CustId);
        Create(customer);
<<<<<<< HEAD
=======
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
MethodBase.GetCurrentMethod().Name, $"END update customer: Id={customer.CustId}, Name={customer.CustName}");
>>>>>>> main
    }

}
