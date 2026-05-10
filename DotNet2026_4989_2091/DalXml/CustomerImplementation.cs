using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    string customerExlPath = @"../xml/customers.xml";
    private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Customer>));
    static List<Customer> customers;
    private const string messageNotFound = "customer id is not found";

    // פונקציה פנימית לקריאה מהקובץ (מחזירה רשימה, לא משנה את הלוגיקה)
    private List<Customer> ReadCustomersFromFile()
    {
        using (StreamReader sr = new StreamReader(customerExlPath))
        {
            customers = xmlSerializer.Deserialize(sr) as List<Customer>;
        }
        return customers ?? new List<Customer>();
    }

    // פונקציה פנימית לכתיבה לקובץ
    private void WriteCustomersToFile(List<Customer> list)
    {
        using (StreamWriter sw = new StreamWriter(customerExlPath))
        {
            xmlSerializer.Serialize(sw, list);
        }
    }

    public int Create(Customer item)
    {
        customers = ReadCustomersFromFile();
        customers.Add(item);
        WriteCustomersToFile(customers);
        return item.CustId;
    }

    public void Delete(int id)
    {
        customers = ReadCustomersFromFile();
        var cust = from c in customers
                   where c.CustId == id
                   select c;
        Customer? cust2 = cust.FirstOrDefault();
        if (cust2 == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        customers.Remove(cust2);
        WriteCustomersToFile(customers);
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        customers = ReadCustomersFromFile();
        var cust = from c in customers
                   where filter(c)
                   select c;
        Customer? cust2 = cust.FirstOrDefault();
        if (cust2 == null)
            throw new DalIdNotFoundExceptions("messageNotFound");
        return cust2;
    }

    public Customer? Read(int id)
    {
        customers = ReadCustomersFromFile();
        var cust = from c in customers
                   where c.CustId == id
                   select c;
        Customer? cust2 = cust.FirstOrDefault();
        if (cust2 == null)
            throw new DalIdNotFoundExceptions("messageNotFound");
        return cust2;
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        customers = ReadCustomersFromFile();
        var list = filter != null ?
               from c in customers
               where filter(c)
               select c
               : customers;
        return list.ToList();
    }

    public void Update(Customer item)
    {
        customers = ReadCustomersFromFile();
        int index = customers.FindIndex(c => c.CustId == item.CustId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        customers[index] = item;
        WriteCustomersToFile(customers);
    }
}