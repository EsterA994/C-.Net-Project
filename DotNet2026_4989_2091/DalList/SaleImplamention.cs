using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class SaleImplamentionL : ISale
    {
        internal static List<int> emptyId = new List<int> { };

        public int Create(Sale sale)
        {
            //לשנות למזהה רץ
            if (sale == null)
                return 0;
            if (emptyId.length > 0)
            {
                Sale newSale = sale with { SaleId = emptyId[0] };
                emptyId.remove(emptyId[0]);
                _sales.Add(newSale);
            }
            else
            {
                //לשנות למזהה רץ
                Product newSale = sale with { SaleId = 1 };
            }
        }
        public Sale Read(int id)
        {
            if (!_sales.contains(SaleId = id))
            {
                throw new IdNotFoundExceptions();
            }
            else
            {
                return _sales.find(SaleId = id);
            }
        }
        public List<Sale> ReadAll()
        {
            return _sales;
        }
        public void Delete(int id)
        {
            if (!_sales.contains(SaleId = id))
            {
                throw new IdNotFoundExceptions();
            }
            else
            {
                _sales.remove(SaleId = id);
                emptyId.add(id);
            }
        }
        public void Update(Sale sale)
        {
            int index = _sales.indexOf(SaleId = sale.SaleId);
            if (index == -1)
            {
                throw new IdNotFoundExceptions();

            }
            else
            {
                _sales[index] = sale;
            }
        }
    }
}
