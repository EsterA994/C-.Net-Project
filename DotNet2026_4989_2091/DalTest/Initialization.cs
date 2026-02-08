using DO;
using DalApi;
//namespace DalTest;

public static class Initialization
{
    private static IDal s_dal;


    private static void CreateProducts()
    {
        s_dal.Product.Create(new Product(100001, "שחמט אלקטרוני", ProdCategory.אלקטרוניקה, 60, 20));
        s_dal.Product.Create(new Product(100002, "הלך לי קלף", ProdCategory.קופסא, 50, 10));
        s_dal.Product.Create(new Product(100003, "אנדרלמוסיה", ProdCategory.קופסא, 80, 15));
        s_dal.Product.Create(new Product(100004, "ביגדיל", ProdCategory.קלפים, 50, 10));
        s_dal.Product.Create(new Product(100005, "נמל תעופה", ProdCategory.קופסא, 120, 8));
        s_dal.Product.Create(new Product(100006, "חבל קפיצה ארוך", ProdCategory.חצר, 35, 20));
        s_dal.Product.Create(new Product(100007, "בובת ניו יורק", ProdCategory.פעוטות, 139, 16));
        s_dal.Product.Create(new Product(100008, "Taki", ProdCategory.קלפים, 40, 10));
        s_dal.Product.Create(new Product(100009, "משחק מגנטים", ProdCategory.הרכבה, 230, 12));
        s_dal.Product.Create(new Product(100010, "כדור", ProdCategory.חצר, 12, 14));
    }

    public static void CreateCustomers()
    {
        s_dal.Customer.Create(new Customer(100001, "אורי כהן", "רחוב הרצל 23", "027651234"));
        s_dal.Customer.Create(new Customer(100002, "נועה לוי", "שדרות ירושלים 145", "025553789"));
        s_dal.Customer.Create(new Customer(100003, "יונתן מזרחי", "רחוב בן גוריון 67", "037894561"));
        s_dal.Customer.Create(new Customer(100004, "תמר אביטל", "רחוב הנשיא 34", "025678234"));
        s_dal.Customer.Create(new Customer(100005, "אליעזר ברק", "שכונת רמות 89", "037652398"));
        s_dal.Customer.Create(new Customer(100006, "שירה דוד", "רחוב הרב קוק 12", "098765432"));
        s_dal.Customer.Create(new Customer(100007, "דניאל שמעוני", "רחוב סוקולוב 56", "025559876"));
        s_dal.Customer.Create(new Customer(100008, "רחל פרידמן", "שדרות בן צבי 103", "027893456"));
        s_dal.Customer.Create(new Customer(100009, "עמית גולן", "רחוב ז'בוטינסקי 78", "037651290"));
        s_dal.Customer.Create(new Customer(100010, "יעל רוזנברג", "רחוב ביאליק 45", "089743210"));

    }
    public static void CreateSales()
    {
        s_dal.Sale.Create(new Sale(101, 100006, 2, 89, false, new DateTime(2024, 12, 20), new DateTime(2025, 1, 15)));
        s_dal.Sale.Create(new Sale(102, 100003, 1, 149, true, new DateTime(2024, 12, 25), new DateTime(2025, 1, 10)));
        s_dal.Sale.Create(new Sale(103, 100005, 3, 199, false, new DateTime(2025, 1, 1), new DateTime(2025, 1, 31)));
        s_dal.Sale.Create(new Sale(104, 100007, 1, 69, false, new DateTime(2024, 12, 15), new DateTime(2025, 2, 1)));
        s_dal.Sale.Create(new Sale(105, 100008, 2, 179, true, new DateTime(2025, 1, 5), new DateTime(2025, 1, 20)));
        s_dal.Sale.Create(new Sale(106, 100009, 1, 299, false, new DateTime(2024, 12, 28), new DateTime(2025, 1, 25)));
        s_dal.Sale.Create(new Sale(107, 100000, 4, 49, false, new DateTime(2025, 1, 10), new DateTime(2025, 2, 10)));
        s_dal.Sale.Create(new Sale(108, 100001, 2, 119, true, new DateTime(2024, 12, 22), new DateTime(2025, 1, 12)));
        s_dal.Sale.Create(new Sale(109, 100002, 1, 249, false, new DateTime(2025, 1, 3), new DateTime(2025, 1, 30)));
        s_dal.Sale.Create(new Sale(110, 100005, 3, 139, true, new DateTime(2024, 12, 18), new DateTime(2025, 1, 18)));
    }
    
    public static void Initialize(IDal dal)
    {
        s_dal = dal;
        CreateProducts();
        CreateCustomers();
        CreateSales();
    }

}
