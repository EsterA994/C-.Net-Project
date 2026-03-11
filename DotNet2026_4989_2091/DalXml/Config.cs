using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal static class Config
    {
        private static string configFileName = "data-config";

        private static int SaleNum = 100;
        private static int ProductNum = 100000;

        public static int saleNum
        {
            get { return SaleNum++; }
        }



        public static int productNum
        {
            get { return ProductNum++; }
        }



    }
}
