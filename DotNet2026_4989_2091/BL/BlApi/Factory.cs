using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Factory
    {
        public static IBl Get() => new Bl();
    }
}
