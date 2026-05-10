using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        public List<SaleInProduct> AddProductToOrder(Order order, int prodId, int amount)
        {
            throw new NotImplementedException();
        }

        public void CalcTotalPrice(Order order)
        {
            throw new NotImplementedException();
        }

        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
        {
            throw new NotImplementedException();
        }

        public void DoOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isClubMember)
        {
            throw new NotImplementedException();
        }
    }
}
