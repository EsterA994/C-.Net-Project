using DalApi;

namespace Dal;

public sealed class DalXml : IDal
{
    public static DalApi.IDal Instance { get; } = new DalXml();

    // 2. בנאי פרטי כדי למנוע יצירת מופעים מבחוץ
    private DalXml() { }


    public IProduct Product => new ProductImplementation();
    public ISale Sale => new SaleImplementation();
    public ICustomer Customer => new CustomerImplementation();
}
