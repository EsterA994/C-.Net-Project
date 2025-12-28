using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class IdNotFoundExceptions: Exception
    {
        public override string Message
        {
            get { return "Id not found "; }
        }
    }

    public class IdAlreadyExistExceptions : Exception
    {
        public override string Message
        {
            get { return "Id already exist "; }
        }
    }
}
