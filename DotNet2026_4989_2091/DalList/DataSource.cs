using DO;
namespace Dal;

internal static class DataSource
{
    internal static List<Sale>? _sales=new List<Sale>();
    internal static List<Product>? _products = new List<Product> ();
    internal static List<Customer>? _customers = new List<Customer> ();


    internal static class Config
    {
        internal const int _minProductId = 100000;
        private static int _curProductId=_minProductId;

        public static int CurProductId
        {
            get { return _curProductId++; }
        }

        internal const int _minSaleId = 100;
        private static int _curSaleId = _minSaleId;

        public static int CurSaleId
        {
            get { return _curSaleId++; }
        }

    }

}
