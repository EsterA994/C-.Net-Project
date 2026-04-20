using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {

        const string PRODUCT_NUM = "ProductNum";

        const string dataPath = @"../xml/data-config.xml";
        static XElement dataXml;

        private static int SaleNum = 100;
        private static int ProductNum = 100000;

        public static int saleNum
        {
            get { return SaleNum++; }
        }



        public static int productNum
        {
            get {
                dataXml = XElement.Load(dataPath);

                var idElement = dataXml.Element(PRODUCT_NUM);

                if (idElement == null)
                    throw new Exception("Element not found in XML");

                ProductNum = (int)idElement;
                ProductNum++;
                idElement.SetValue(ProductNum);
                dataXml.Save(dataPath);
                return ProductNum; 
            }
        }



    }
}
