

using DalApi;
using DO;
using System.Collections.Generic;
using static Dal.DataSource;
using static Dal.DataSource.Config;

namespace Dal;

internal class SaleImplamention : ISale
{
    internal static List<int> emptyId = new List<int>();
    private const string messageNotFound = "sale id is not found";
    private const string messageAlreadyExists = "sale id is already exists";

    public int Create(Sale sale)
    {
        Sale newSale;
        if (emptyId.Count > 0)
        {
            newSale = sale with { SaleId = emptyId[0] };
            emptyId.Remove(emptyId[0]);
        }
        else
        {
            newSale = sale with { SaleId = CurSaleId };
        }
        _sales?.Add(newSale);

        return newSale.ProdId;
    }
    public Sale? Read(int id)
    {
        var sale = from s in _sales
                   where s.ProdId == id
                   select s;
            if (sale == null)
        
            throw new DalIdNotFoundExceptions(messageNotFound);
        return (Sale)sale;

    }
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        var list = filter != null ?
                   from s in _sales
                   where filter(s)
                   select s
                   : _sales;
        return list.ToList();
    }
    public void Delete(int id)
    {
        var sale = from s in _sales
                   where s.SaleId == id
                   select s;
        if (sale == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _sales?.Remove((Sale)sale);
        emptyId.Add(id);
    }
    public void Update(Sale sale)//
    {
        int index = _sales.FindIndex(s => s.SaleId == sale.SaleId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);

        }
        _sales[index] = sale;
    }
}
