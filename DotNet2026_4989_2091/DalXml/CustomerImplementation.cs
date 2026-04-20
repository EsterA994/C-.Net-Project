
using DalApi;
using DO;
using System.Reflection;
using System.Xml.Linq;

namespace Dal
{
    internal class CustomerImplementation:ICustomer
    {
        const string ARRAY_OF_CUSTOMER = "ArrayOfCustomer";
        XElement customers = new XElement(ARRAY_OF_CUSTOMER);
        public int Create(Customer customer)
        {
           
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
            var list = filter != null ?
                       from c in _customers
                       where filter(c)
                       select c
                        : _customers;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"END read all customers: count={list?.ToList().Count}");
            return list.ToList();
        }

        public void Delete(int id)
        {
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
            if (Read(customer.CustId) == null)
                throw new DalIdNotFoundExceptions(messageNotFound);
            Delete(customer.CustId);
            Create(customer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
    MethodBase.GetCurrentMethod().Name, $"END update customer: Id={customer.CustId}, Name={customer.CustName}");
        }

        public int Create(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
            throw new NotImplementedException();
        }

        Customer? ICrud<Customer>.Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
