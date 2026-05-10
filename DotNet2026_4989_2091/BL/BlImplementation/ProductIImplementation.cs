
using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class ProductIImplementation : IProduct
    {
        public int Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetSales(ProductInOrder productInOrder, bool isClubMember)
        {
            throw new NotImplementedException();
        }

        public Product? Read(Func<Product, bool> filter)
        {
            throw new NotImplementedException();
        }

        public Product? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
