using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml;

internal static class Config
{

    const string PRODUCT_NUM = "ProductNum";
    const string SALE_NUM = "SaleNum";

    const string dataPath = @"../xml/data-config.xml";
    private static XElement dataXml;

    private static int saleNum = 100;

    public static int SaleNum
    {
        get
        {
            dataXml = XElement.Load(dataPath);

            XElement idElement = dataXml.Element(SALE_NUM);

            if (idElement == null)
                throw new Exception("Element not found in XML");

            saleNum = (int)idElement;
            saleNum++;
            idElement.SetValue(saleNum);
            dataXml.Save(dataPath);
            return saleNum;
        }
    }


    private static int productNum = 100000;
    public static int ProductNum
    {
        get {
            dataXml = XElement.Load(dataPath);

            XElement? idElement = dataXml.Element(PRODUCT_NUM);

            if (idElement == null)
                throw new Exception("Element not found in XML");

            productNum = (int)idElement;
            productNum++;
            idElement.SetValue(productNum);
            dataXml.Save(dataPath);
            return productNum; 
        }
    }




}
