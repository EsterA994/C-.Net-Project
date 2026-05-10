
using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class ProductImplementationation : IProduct
    {
        public int Create(Product item)
        {
            throw new NotIImplementationedException();
        }

        public void Delete(int id)
        {
            throw new NotIImplementationedException();
        }

        public void GetSales(ProductInOrder productInOrder, bool isClubMember)
        {
            throw new NotIImplementationedException();
        }

        public Product? Read(Func<Product, bool> filter)
        {
            throw new NotIImplementationedException();
        }

        public Product? Read(int id)
        {
            throw new NotIImplementationedException();
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            throw new NotIImplementationedException();
        }

        public void Update(Product item)
        {
            throw new NotIImplementationedException();
        }
    }
}
