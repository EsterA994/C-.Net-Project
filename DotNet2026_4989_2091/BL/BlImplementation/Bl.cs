using BL.BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class Bl : IBl
    {
        // האובייקטים נוצרים פעם אחת בלבד כאן:
        private readonly IProduct _product = new ProductImplementation();
        private readonly ISale _sale = new SaleImplementation();
        private readonly ICustomer _customer = new CustomerImplementation();
        private readonly IOrder _order = new OrderImplementation();

        // ה-Properties רק מחזירים את האובייקטים הקיימים (בלי new!)
        IProduct IBl.Product => _product;
        ISale IBl.Sale => _sale;
        ICustomer IBl.Customer => _customer;
        IOrder IBl.Order => _order;
    }
}