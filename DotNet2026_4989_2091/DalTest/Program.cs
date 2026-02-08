using Dal;
using DalApi;
using DO;


public class Program
{
    private static IDal s_dal = new DalList();
    static void Main(string[] args)
    {
        try
        {
            Initialization.Initialize(s_dal);
        }
        catch (DalIdNotFoundExceptions ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DalIdAlreadyExistExceptions ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("error...");
        }
        DisplayMenu();

    }
    private static void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("ברוכים הבאים לחנות המשחקים הגדולה בעולם!");
            Console.WriteLine("אנא בחרו באפשרות הרצויה:");
            Console.WriteLine("1. ניהול מוצרים");
            Console.WriteLine("2. ניהול לקוחות");
            Console.WriteLine("3. ניהול מבצעים");
            Console.WriteLine("4. יציאה מהתוכנית");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("בחירה לא תקינה, אנא נסה שוב.");
            }
            switch (choice)
            {
                case 1:
                    ProductManagement();
                    break;
                case 2:
                    CustomerManagement();
                    break;
                case 3:
                    SaleManagement();
                    break;
                case 4:
                    exit();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("בחירה לא תקינה, אנא נסה שוב.");
                    break;
            }
        }
    }
    private static void ProductManagement()
    {
        Console.WriteLine("ניהול מוצרים");
        int choice = MenuCrud();
        switch (choice)
        {
            case 1:
                Console.WriteLine(s_dal.Product.Create(GetNewProduct()));
                break;
            case 2:
                Console.WriteLine(s_dal.Product.Read(GetId()));
                break;
            case 3:
                s_dal.Product.Update(GetNewProduct(GetId()));
                break;
            case 4:
                s_dal.Product.Delete(GetId());
                break;
            case 5:
                foreach (var item in s_dal.Product.ReadAll())
                {
                    Console.WriteLine(item);
                }
                break;
            case 6:
                DisplayMenu();
                return;
            case 7:
                exit();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("בחירה לא תקינה, אנא נסה שוב.");
                break;
        }
    }
    private static void CustomerManagement()
    {
        Console.WriteLine("ניהול לקוחות");
        int choice = MenuCrud();
        switch (choice)
        {
            case 1:
                Console.WriteLine(s_dal.Customer.Create(GetNewCustomer()));
                break;
            case 2:
                Console.WriteLine(s_dal.Customer.Read(GetId()));
                break;
            case 3:
                s_dal.Customer.Update(GetNewCustomer(GetId()));
                break;
            case 4:
                s_dal.Customer.Delete(GetId());
                break;
            case 5:
                foreach (var item in s_dal.Customer.ReadAll())
                {
                    Console.WriteLine(item);
                }
                break;
            case 6:
                DisplayMenu();
                break;
            case 7:
                exit();
                break;
            default:
                Console.WriteLine("בחירה לא תקינה, אנא נסה שוב.");
                break;
        }
    }
    private static void SaleManagement()
    {
        Console.WriteLine("ניהול מבצעים");
        int choice = MenuCrud();
        switch (choice)
        {
            case 1:
                Console.WriteLine(s_dal.Sale.Create(GetNewSale(0)));
                break;
            case 2:
                Console.WriteLine(s_dal.Sale.Read(GetId()));
                break;
            case 3:
                s_dal.Sale.Update(GetNewSale(GetId()));
                break;
            case 4:
                s_dal.Sale.Delete(GetId());
                break;
            case 5:
                foreach (var item in s_dal.Sale.ReadAll())
                {
                    Console.WriteLine(item);
                }
                break;
            case 6:
                DisplayMenu();
                break;
            case 7:
                exit();
                break;
            default:
                Console.WriteLine("בחירה לא תקינה, אנא נסה שוב.");
                break;
        }
    }
    private static int MenuCrud()
    {
        Console.WriteLine("הקש את בחירתך:");
        Console.WriteLine("1. יצירת רשומה חדשה");
        Console.WriteLine("2. קריאת רשומה קיימת");
        Console.WriteLine("3. עדכון רשומה קיימת");
        Console.WriteLine("4. מחיקת רשומה קיימת");
        Console.WriteLine("5. קריאת הרשימה");
        Console.WriteLine("6. חזרה לתפריט הראשי");
        Console.WriteLine("7. יציאה מהתוכנית");
        int choice = int.Parse(Console.ReadLine());
        return choice;

    }
    private static void exit()
    {
        Console.WriteLine("תודה שביקרת בחנות שלנו! להתראות.");
    }
    private static Product GetNewProduct(int id = 0)
    {
        Console.WriteLine("הזן את פרטי המוצר:");
        Console.Write("שם מוצר: ");
        string name = Console.ReadLine();
        Console.Write("קטגוריה (אלקטרוניקה, קופסא, קלפים, חצר, פעוטות, הרכבה): ");
        ProdCategory category = (ProdCategory)Enum.Parse(typeof(ProdCategory), Console.ReadLine());
        Console.Write("מחיר: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("כמות במלאי: ");
        int stock = int.Parse(Console.ReadLine());
        return new Product(id, name, category, price, stock);
    }
    public static Customer GetNewCustomer(int id = 0)
    {
        Console.WriteLine("הזן את פרטי הלקוח:");
        if (id == 0)
        {
            Console.WriteLine("מספר זהות: ");
            id = int.Parse(Console.ReadLine());
        }
        Console.Write("שם מלא: ");
        string name = Console.ReadLine();
        Console.Write("כתובת: ");
        string address = Console.ReadLine();
        Console.Write("טלפון: ");
        string phone = Console.ReadLine();
        return new Customer(id, name, address, phone);
    }
    public static Sale GetNewSale(int SaleId = 1111111)
    {
        Console.WriteLine("הזן את פרטי המבצע:");
        Console.Write("מזהה מוצר: ");
        int ProdId = int.Parse(Console.ReadLine());
        Console.Write("כמות: ");
        int MinRequireQuantity = int.Parse(Console.ReadLine());
        Console.Write("מחיר מבצע: ");
        double PriceInSale = double.Parse(Console.ReadLine());
        Console.Write("האם המבצע פעיל? (true/false): ");
        bool JustForClub = bool.Parse(Console.ReadLine());
        Console.Write("תאריך התחלה (yyyy-MM-dd): ");
        DateTime StartDateSale = DateTime.Parse(Console.ReadLine());
        Console.Write("תאריך סיום (yyyy-MM-dd): ");
        DateTime StopDateSale = DateTime.Parse(Console.ReadLine());
        return new Sale(SaleId, ProdId, MinRequireQuantity, PriceInSale, JustForClub, StartDateSale, StopDateSale);
    }
    private static int GetId()
    {
        Console.Write("הזן את המזהה: ");
        int id = int.Parse(Console.ReadLine());
        return id;
    }
}