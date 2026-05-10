using DalApi;
using DalXml;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class SaleImplementation : ISale
{
    string saleExlPath = @"../xml/sales.xml";
    private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sale>));
    static List<Sale> sales;
    private const string messageNotFound = "sale id is not found";

    private List<Sale> ReadFromFile()
    {
        using (StreamReader sr = new StreamReader(saleExlPath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;

        }
        return sales ?? new List<Sale>();
    }

    private void WriteToFile(List<Sale> sales)
    {

        using (StreamWriter sw = new StreamWriter(saleExlPath))
        {
            xmlSerializer.Serialize(sw, sales);
        }
    }
    public int Create(Sale item)
    {
        sales = ReadFromFile();
        Sale newSale;

        newSale = item with { SaleId = Config.SaleNum };
        sales.Add(newSale);

        WriteToFile(sales);
        return newSale.SaleId;
    }

    public void Delete(int id)
    {
        sales = ReadFromFile();
        var sale = from s in sales
                   where s.SaleId == id
                   select s;
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        sales.Remove(sale2);
        WriteToFile(sales);
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        sales = ReadFromFile();
        var sale = from s in sales
                   where filter(s)
                   select s;
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return sale2;
    }

    public Sale? Read(int id)
    {
        sales = ReadFromFile();
        var sale = from s in sales
                   where s.SaleId == id
                   select s;
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return sale2;
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        sales = ReadFromFile();
        var list = filter != null ?
               from s in sales
               where filter(s)
               select s
               : sales;
        return list.ToList();

    }

    public void Update(Sale item)
    {
        sales = ReadFromFile();
        int index = sales.FindIndex(s => s.SaleId == item.SaleId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        sales[index] = item;

        WriteToFile(sales);
    }

}

