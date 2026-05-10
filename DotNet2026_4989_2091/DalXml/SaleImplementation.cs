using DalApi;
using DalXml;
using DO;
using System.Xml.Serialization;
namespace Dal
{
    internal class SaleImplementation : ISale
    {
        string saleExlPath = @"../xml/sales.xml";
        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sale>));
        static List<Sale> sales;
        private const string messageNotFound = "sale id is not found";
        private List<Sale> ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(saleExlPath))
            {
                sales = xmlSerializer.Deserialize(sr) as List<Sale>;

            }
            return sales ?? new List<Sale>();
        }

        private void WriteToFile(List<Sale> sales)
        {

            using (StreamWriter sw = new StreamWriter(saleExlPath))
            {
                xmlSerializer.Serialize(sw, sales);
            }
        }
        public int Create(Sale item)
        {
            sales = ReadFromFile();
            Sale newSale;

            newSale = item with { SaleId = Config.SaleNum };
            sales.Add(newSale);

            WriteToFile(sales);
            return newSale.SaleId;

        }


        public void Delete(int id)
        {
            sales = ReadFromFile();
            var sale = from s in sales
                       where s.SaleId == id
                       select s;
            Sale? sale2 = sale.FirstOrDefault();
            if (sale2 == null)
            {
                throw new DalIdNotFoundExceptions(messageNotFound);
            }
            sales.Remove(sale2);
            WriteToFile(sales);
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            sales = ReadFromFile();
            var sale = from s in sales
                       where filter(s)
                       select s;
            Sale? sale2 = sale.FirstOrDefault();
            if (sale2 == null)
                throw new DalIdNotFoundExceptions("messageNotFound");
            return sale2;
        }

        public Sale? Read(int id)
        {
            sales = ReadFromFile();
            var sale = from s in sales
                       where s.SaleId == id
                       select s;
            Sale? sale2 = sale.FirstOrDefault();
            if (sale2 == null)
                throw new DalIdNotFoundExceptions("messageNotFound");
            return sale2;
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            sales = ReadFromFile();
            var list = filter != null ?
                   from s in sales
                   where filter(s)
                   select s
                   : sales;
            return list.ToList();

        }

        public void Update(Sale item)
        {
            sales = ReadFromFile();
            int index = sales.FindIndex(s => s.SaleId == item.SaleId);
            if (index == -1)
            {
                throw new DalIdNotFoundExceptions(messageNotFound);
            }
            sales[index] = item;

            WriteToFile(sales);
        }

    }
}
//}
//using DalApi;
//using DalXml;
//using DO;
//using System.Xml.Serialization;
//using System.IO;
//using System.Linq;
//using System.Collections.Generic;
//using System;

//namespace Dal
//{
//    internal class SaleImplementation : ISale
//    {
//        private readonly string saleXmlPath= @"../xml/sales.xml";
//        private readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sale>));
//        private const string messageNotFound = "sale id is not found";
//                static List<Sale> sales;

//        // Read helper: reads file (using ...) and returns list (never null)
//        private List<Sale> ReadFromFile()
//        {
//            using (StreamReader sr = new StreamReader(saleXmlPath))
//                            {
//                              sales = xmlSerializer.Deserialize(sr) as List<Sale>;

//                           }
//                return sales ?? new List<Sale>();
//        }

//        private void WriteToFile(List<Sale> sales)
//        {

//            using (StreamWriter sw = new StreamWriter(saleXmlPath))
//            {
//                xmlSerializer.Serialize(sw, sales);
//           }
//        }

//        public int Create(Sale item)
//        {
//            //לבדוק אם צריך ולידציה!!!!!!!!!!
//            if (item.MinRequireQuantity <= 0)
//                throw new ArgumentException("MinRequireQuantity must be > 0", nameof(item.MinRequireQuantity));
//            if (item.PriceInSale < 0)
//                throw new ArgumentException("PriceInSale must be >= 0", nameof(item.PriceInSale));

//            var sales = ReadFromFile();
//            var newSale = item with { SaleId = Config.SaleNum };
//            sales.Add(newSale);
//            WriteToFile(sales);
//            return newSale.SaleId;
//        }

//        public void Delete(int id)
//        {
//            var sales = ReadFromFile();
//            var sale = sales.FirstOrDefault(s => s.SaleId == id);
//            if (sale == null)
//                throw new DalIdNotFoundExceptions(messageNotFound);

//            sales.Remove(sale);
//            WriteToFile(sales);
//        }

//        public Sale? Read(Func<Sale, bool> filter)
//        {
//            var sales = ReadFromFile();
//            var sale = sales.FirstOrDefault(s => filter(s));
//            if (sale == null)
//                throw new DalIdNotFoundExceptions(messageNotFound);
//            return sale;
//        }

//        public Sale? Read(int id)
//        {
//            var sales = ReadFromFile();
//            var sale = sales.FirstOrDefault(s => s.SaleId == id);
//            if (sale == null)
//                throw new DalIdNotFoundExceptions(messageNotFound);
//            return sale;
//        }

//        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
//        {
//            var sales = ReadFromFile();
//            return filter != null ? sales.Where(filter).ToList() : new List<Sale>(sales);
//        }

//        public void Update(Sale item)
//        {
//            // basic validation
//            if (item.MinRequireQuantity <= 0)
//                throw new ArgumentException("MinRequireQuantity must be > 0", nameof(item.MinRequireQuantity));
//            if (item.PriceInSale < 0)
//                throw new ArgumentException("PriceInSale must be >= 0", nameof(item.PriceInSale));
//            if (item.StartDateSale.HasValue && item.StopDateSale.HasValue && item.StartDateSale > item.StopDateSale)
//                throw new ArgumentException("StartDateSale must be <= StopDateSale");

//            var sales = ReadFromFile();
//            int index = sales.FindIndex(s => s.SaleId == item.SaleId);
//            if (index == -1)
//                throw new DalIdNotFoundExceptions(messageNotFound);

//            sales[index] = item;
//            WriteToFile(sales);
//        }
//    }
//}