using System;
using BO;
using BlApi;


namespace BlTest;

internal class Program
{
    // השדה הראשי שדרכו ניגשים לכל הלוגיקה
    static readonly IBl s_bl = Factory.Get();

    static void Main(string[] args)
    {
        // אם תרצי לאתחל נתונים מה-DAL, שחררי את ההערה כאן:
        // DalTest.Initialization.Do(); 

        Console.WriteLine("======= Store Management System - BL Test =======");

        int choice;
        do
        {
            Console.WriteLine("\n[ Main Menu ]");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Product Actions");
            Console.WriteLine("2: Customer Actions");
            Console.WriteLine("3: Sale Actions");
            Console.WriteLine("4: Shopping Cart (Order Actions)");

            choice = ReadInt("Your choice: ");

            switch (choice)
            {
                case 1: ProductMenu(); break;
                case 2: CustomerMenu(); break;
                case 3: SaleMenu(); break;
                case 4: OrderMenu(); break;
                case 0: Console.WriteLine("Exiting program... Goodbye!"); break;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        } while (choice != 0);
    }

    #region Product Menu
    static void ProductMenu()
    {
        Console.WriteLine("\n--- Product Menu ---");
        Console.WriteLine("1: Create | 2: Read (ID) | 3: ReadAll | 4: Update | 5: Delete | 0: Back");
        int choice = ReadInt("Choice: ");

        try
        
        {
            switch (choice)
            {
                case 1: // Create
                    Product p = new Product();
                    p.ProdName = ReadString("Product Name: ");
                    p.Price = ReadDouble("Price: ");
                    p.QuantityInStock = ReadInt("Stock Quantity: ");
                    p.ProdCategory = ReadEnum<ProdCategory>("Select Category");
                    p.Sales = new List<SaleInProduct>(); // רשימה ריקה בהתחלה
                    Console.WriteLine($"Product Created! New ID: {s_bl.Product.Create(p)}");
                    break;
                case 2: // Read
                    int id = ReadInt("Enter Product ID to view: ");
                    var found = s_bl.Product.Read(id);
                    Console.WriteLine(found?.ToString() ?? "Product not found.");
                    break;
                case 3: // ReadAll
                    s_bl.Product.ReadAll().ForEach(item => Console.WriteLine(item.ToString() + "\n-----------------"));
                    break;
                case 4: // Update
                    Product up = new Product();
                    up.ProdId = ReadInt("ID of product to update: ");
                    up.ProdName = ReadString("New Name: ");
                    up.Price = ReadDouble("New Price: ");
                    up.QuantityInStock = ReadInt("New Stock: ");
                    up.ProdCategory = ReadEnum<ProdCategory>("New Category");
                    s_bl.Product.Update(up);
                    Console.WriteLine("Product updated successfully.");
                    break;
                case 5: // Delete
                    s_bl.Product.Delete(ReadInt("ID to delete: "));
                    Console.WriteLine("Product deleted.");
                    break;
            }
        }
        catch (Exception ex) { PrintError(ex); }
    }
    #endregion

    #region Customer Menu
    static void CustomerMenu()
    {
        Console.WriteLine("\n--- Customer Menu ---");
        Console.WriteLine("1: Create | 2: Read | 3: ReadAll | 4: Update | 5: Delete | 6: Check If Exists | 0: Back");
        int choice = ReadInt("Choice: ");

        try
        {
            switch (choice)
            {
                case 1:
                    Customer c = new Customer();
                    c.CustId = ReadInt("Customer ID (Manual): ");
                    c.CustName = ReadString("Name: ");
                    c.CustAddress = ReadString("Address: ");
                    c.CustPhone = ReadString("Phone: ");
                    s_bl.Customer.Create(c);
                    Console.WriteLine("Customer added.");
                    break;
                case 2:
                    Console.WriteLine(s_bl.Customer.Read(ReadInt("Enter ID: "))?.ToString() ?? "Not found.");
                    break;
                case 3:
                    s_bl.Customer.ReadAll().ForEach(item => Console.WriteLine(item.ToString()));
                    break;
                case 4:
                    Customer uc = new Customer();
                    uc.CustId = ReadInt("Enter ID to update: ");
                    uc.CustName = ReadString("New Name: ");
                    uc.CustAddress = ReadString("New Address: ");
                    uc.CustPhone = ReadString("New Phone: ");
                    s_bl.Customer.Update(uc);
                    Console.WriteLine("Customer updated.");
                    break;
                case 6:
                    int checkId = ReadInt("Check ID: ");
                    Console.WriteLine(s_bl.Customer.IsExsitsCust(checkId) ? "Exists." : "Does not exist.");
                    break;
            }
        }
        catch (Exception ex) { PrintError(ex); }
    }
    #endregion

    #region Sale Menu
    static void SaleMenu()
    {
        Console.WriteLine("\n--- Sale Menu ---");
        Console.WriteLine("1: Create | 2: Read | 3: ReadAll | 4: Update | 5: Delete | 0: Back");
        int choice = ReadInt("Choice: ");

        try
        {
            switch (choice)
            {
                case 1:
                    Sale s = new Sale();
                    s.ProdId = ReadInt("Product ID for sale: ");
                    s.MinRequireQuantity = ReadInt("Minimum quantity for sale: ");
                    s.PriceInSale = ReadDouble("Sale Price: ");
                    s.JustForClub = ReadBool("Club Members only? (y/n): ");
                    s.StartDateSale = DateTime.Now;
                    s.StopDateSale = DateTime.Now.AddDays(7);
                    Console.WriteLine($"Sale created! ID: {s_bl.Sale.Create(s)}");
                    break;
                case 3:
                    s_bl.Sale.ReadAll().ForEach(item => Console.WriteLine(item.ToString()));
                    break;
                case 5:
                    s_bl.Sale.Delete(ReadInt("Sale ID to delete: "));
                    Console.WriteLine("Sale deleted.");
                    break;
            }
        }
        catch (Exception ex) { PrintError(ex); }
    }
    #endregion

    #region Order Menu (The Business Logic Engine)
    static void OrderMenu()
    {
        // יצירת הזמנה חדשה בזיכרון
        Order currentOrder = new Order { ProductsList = new List<ProductInOrder>(), FinalPrice = 0 };
        currentOrder.IsPreferredCust = ReadBool("Are you a preferred customer? (y/n): ");

        int choice;
        do
        {
            Console.WriteLine("\n--- Current Shopping Cart ---");
            Console.WriteLine("1: Add/Update Product in Cart");
            Console.WriteLine("2: View My Cart (Check Calculations)");
            Console.WriteLine("3: Finalize and DoOrder");
            Console.WriteLine("0: Cancel and Return to Main Menu");

            choice = ReadInt("Choice: ");

            try
            {
                switch (choice)
                {
                    case 1:
                        int pid = ReadInt("Product ID: ");
                        int amount = ReadInt("Amount: ");

                        // קריאה לפונקציה המרכזית ב-BL
                        var salesApplied = s_bl.Order.AddProductToOrder(currentOrder, pid, amount);

                        Console.WriteLine("\nProduct added/updated! Sales applied for this product:");
                        if (salesApplied.Any())
                            salesApplied.ForEach(s => Console.WriteLine($" - Sale {s.SaleId}: {s.Price} per {s.AmountForSale} units."));
                        else
                            Console.WriteLine(" - No sales applicable for this product.");
                        break;

                    case 2:
                        Console.WriteLine("\n=== Order Summary ===");
                        Console.WriteLine(currentOrder.ToString());
                        break;

                    case 3:
                        if (!currentOrder.ProductsList.Any()) throw new Exception("Cart is empty!");
                        s_bl.Order.DoOrder(currentOrder);
                        Console.WriteLine("Success! Order processed and stock updated in DAL.");
                        return;
                }
            }
            catch (Exception ex) { PrintError(ex); }

        } while (choice != 0);
    }
    #endregion

    #region Helper Methods (To make the code "Perfect")

    static int ReadInt(string msg)
    {
        Console.Write(msg);
        int.TryParse(Console.ReadLine(), out int res);
        return res;
    }

    static double ReadDouble(string msg)
    {
        Console.Write(msg);
        double.TryParse(Console.ReadLine(), out double res);
        return res;
    }

    static string ReadString(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine() ?? "";
    }

    static bool ReadBool(string msg)
    {
        Console.Write(msg);
        string input = Console.ReadLine()?.ToLower() ?? "";
        return input == "y" || input == "true" || input == "yes";
    }

    static T ReadEnum<T>(string msg) where T : struct, Enum
    {
        Console.WriteLine($"{msg}:");
        var values = Enum.GetValues(typeof(T));
        foreach (var v in values)
            Console.WriteLine($"{(int)v}: {v}");

        int choice = ReadInt("Select value: ");
        if (!Enum.IsDefined(typeof(T), choice))
        {
            Console.WriteLine("Invalid choice, picking first option by default.");
            return (T)values.GetValue(0)!;
        }
        return (T)Enum.ToObject(typeof(T), choice);
    }

    static void PrintError(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[ERROR]: {ex.Message}");
        if (ex.InnerException != null)
            Console.WriteLine($"[Inner Cause]: {ex.InnerException.Message}");
        Console.ResetColor();
    }
    #endregion
}