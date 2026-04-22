

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
<<<<<<< HEAD
    private const string messageAlreadyExists = "sale id is already exists";
=======
>>>>>>> main

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
    public Sale? Read(Func<Sale, bool> filter)
    {
        var sale = from s in _sales
                   where filter(s)
                   select s;
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return sale2;
    }
    public Sale? Read(int id)
    {
        var sale = from s in _sales
                   where s.ProdId == id
                   select s;
<<<<<<< HEAD
            if (sale == null)
        
            throw new DalIdNotFoundExceptions(messageNotFound);
        return (Sale)sale;
=======
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
            throw new DalIdNotFoundExceptions(messageNotFound);
        return sale2;
>>>>>>> main

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
<<<<<<< HEAD
        if (sale == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _sales?.Remove((Sale)sale);
=======
        Sale? sale2 = sale.FirstOrDefault();
        if (sale2 == null)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
        }
        _sales?.Remove(sale2);
>>>>>>> main
        emptyId.Add(id);
    }
    public void Update(Sale sale)//
    {
        int index = _sales.FindIndex(s => s.SaleId == sale.SaleId);
        if (index == -1)
        {
            throw new DalIdNotFoundExceptions(messageNotFound);
<<<<<<< HEAD

=======
>>>>>>> main
        }
        _sales[index] = sale;
    }

}
