

using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class SaleImplamention : ISale
{
    internal static List<int> emptyId = new List<int>();

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
            //לשנות למזהה רץ
            newSale = sale with { SaleId = 1 };
        }
        _sales?.Add(newSale);

        return newSale.ProdId;
    }
    public Sale? Read(int id)
    {
        if (_sales?.Any(s => s.ProdId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        return _sales?.Find(p => p.ProdId == id);

    }
    public List<Sale> ReadAll()
    {
        return _sales;
    }
    public void Delete(int id)
    {
        if (_sales?.Any(s => s.SaleId == id) == null)
        {
            throw new IdNotFoundExceptions();
        }
        _sales?.RemoveAll(s => s.SaleId == id);
        emptyId.Add(id);
    }
    public void Update(Sale sale)
    {
        int index = _sales.FindIndex(s => s.SaleId == sale.SaleId);
        if (index == -1)
        {
            throw new IdNotFoundExceptions();

        }
        _sales[index] = sale;
    }
}
