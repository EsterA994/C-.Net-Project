using DO;
using DalApi;
using Dal;

namespace DalTest;

public static class Initialization
{
    private static IDal s_dal;

    private static void CreateProducts()
    {
        ProductImplemention product = new ProductImplemention();
        product.Create(new Product(1, "שחמט אלקטרוני", ProdCategory.אלקטרוניקה, 60, 20));
        product.Create(new Product(2, "הלך לי קלף", ProdCategory.קופסא, 50, 10));
        product.Create(new Product(3, "אנדרלמוסיה", ProdCategory.קופסא, 80, 15));
        product.Create(new Product(4, "ביגדיל", ProdCategory.קלפים, 50, 10));
        product.Create(new Product(5, "נמל תעופה", ProdCategory.קופסא, 120, 8));
        product.Create(new Product(6, "חבל קפיצה ארוך", ProdCategory.חצר, 35, 20));
        product.Create(new Product(7, "בובת ניו יורק", ProdCategory.פעוטות, 139, 16));
        product.Create(new Product(8, "Taki", ProdCategory.קלפים, 40, 10));
        product.Create(new Product(9, "משחק מגנטים", ProdCategory.הרכבה, 230, 12));
        product.Create(new Product(10, "כדור", ProdCategory.חצר, 12, 14));
    }

    public static void CreateCustomers()
    {
        CustomerImplemention customer = new CustomerImplemention();
        customer.Create(new Customer(100001, "אורי כהן", "רחוב הרצל 23", "027651234"));
        customer.Create(new Customer(100002, "נועה לוי", "שדרות ירושלים 145", "025553789"));
        customer.Create(new Customer(100003, "יונתן מזרחי", "רחוב בן גוריון 67", "037894561"));
        customer.Create(new Customer(100004, "תמר אביטל", "רחוב הנשיא 34", "025678234"));
        customer.Create(new Customer(100005, "אליעזר ברק", "שכונת רמות 89", "037652398"));
        customer.Create(new Customer(100006, "שירה דוד", "רחוב הרב קוק 12", "098765432"));
        customer.Create(new Customer(100007, "דניאל שמעוני", "רחוב סוקולוב 56", "025559876"));
        customer.Create(new Customer(100008, "רחל פרידמן", "שדרות בן צבי 103", "027893456"));
        customer.Create(new Customer(100009, "עמית גולן", "רחוב ז'בוטינסקי 78", "037651290"));
        customer.Create(new Customer(100010, "יעל רוזנברג", "רחוב ביאליק 45", "089743210"));

    }
    public static void CreateSales()
    {
        SaleImplamention sale = new SaleImplamention();
        sale.Create(new Sale(1, 101, 2, 89, false, new DateTime(2024, 12, 20), new DateTime(2025, 1, 15)));
        sale.Create(new Sale(2, 102, 1, 149, true, new DateTime(2024, 12, 25), new DateTime(2025, 1, 10)));
        sale.Create(new Sale(3, 103, 3, 199, false, new DateTime(2025, 1, 1), new DateTime(2025, 1, 31)));
        sale.Create(new Sale(4, 104, 1, 69, false, new DateTime(2024, 12, 15), new DateTime(2025, 2, 1)));
        sale.Create(new Sale(5, 105, 2, 179, true, new DateTime(2025, 1, 5), new DateTime(2025, 1, 20)));
        sale.Create(new Sale(6, 106, 1, 299, false, new DateTime(2024, 12, 28), new DateTime(2025, 1, 25)));
        sale.Create(new Sale(7, 107, 4, 49, false, new DateTime(2025, 1, 10), new DateTime(2025, 2, 10)));
        sale.Create(new Sale(8, 108, 2, 119, true, new DateTime(2024, 12, 22), new DateTime(2025, 1, 12)));
        sale.Create(new Sale(9, 109, 1, 249, false, new DateTime(2025, 1, 3), new DateTime(2025, 1, 30)));
        sale.Create(new Sale(10, 110, 3, 139, true, new DateTime(2024, 12, 18), new DateTime(2025, 1, 18)));
    }
    public static void Initialize(IDal dal)
    {
        s_dal = dal;
        CreateProducts();
        CreateCustomers();
        CreateSales();
    }

}
