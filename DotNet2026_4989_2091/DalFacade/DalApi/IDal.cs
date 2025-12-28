using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        IProduct Product { get; }
        ISale Sale { get; }
        ICustomer Customer { get; }
    }
}
