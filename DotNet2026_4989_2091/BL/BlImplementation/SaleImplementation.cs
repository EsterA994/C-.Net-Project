using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class SaleImplementationation : ISale
    {
        public int Create(Sale item)
        {
            throw new NotIImplementationedException();
        }

        public void Delete(int id)
        {
            throw new NotIImplementationedException();
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            throw new NotIImplementationedException();
        }

        public Sale? Read(int id)
        {
            throw new NotIImplementationedException();
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            throw new NotIImplementationedException();
        }

        public void Update(Sale item)
        {
            throw new NotIImplementationedException();
        }
    }
}

