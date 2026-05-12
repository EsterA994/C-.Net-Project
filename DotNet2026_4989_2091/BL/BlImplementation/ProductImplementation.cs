
using BlApi;
using BO;

using static BO.Tools;
namespace BlImplementation;

//לבדוק שוב את כל הפונקציות לבדוק מה נכון בין קשר של טיפוסים כמו SALE עם פרודקט או מה עם פונקצית UPDATE צריך להתייחס אליה? ובנוסף לבדוק את כל הקשרים גם עם CUSTOMER וכולי
internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;


    public int Create(BO.Product item)
    {
        // 1. שלב הוולידציה - בדיקה עסקית מקיפה לפני כל פעולה
        ValidateProduct(item);

        try
        {
            // 2. המרה לישות נתונים (DO) באמצעות ה-Tools
            DO.Product doProduct = item.ToDO();

            // 3. פנייה ל-DAL לביצוע היצירה
            // ה-DAL מחזיר את המזהה החדש שנוצר
            return _dal.Product.Create(doProduct);
        }
        catch (DO.DalIdAlreadyExistExceptions ex) // תפיסת חריגה מה-DAL
        {
            // 4. עטיפה בחריגת BL ושליחה עם ה-InnerException המקורי
            throw new BO.BlIdAlreadyExistExceptions($"Product with ID {item.ProdId} already exists in the system.", ex);
        }
    }

    public void Delete(int id)
    {
        // 1. Validation: Ensure the ID is a valid positive number
        if (id <= 0)
            throw new BO.BlInvalidInputException("Invalid ID. Product ID must be a positive number.");

        // 2. Check if the product exists in the DAL
        try
        {
            _dal.Product.Read(id);
        }
        catch (DO.DalIdNotFoundExceptions ex)
        {
            throw new BO.BlDoesNotExistException($"Product with ID {id} was not found.", ex);
        }

        // 4. Cascade Delete: Remove all associated sales first
        // We fetch all sales belonging to this product and delete them one by one
        var productSales = _dal.Sale.ReadAll(s => s.ProdId == id);
        productSales.ToList().ForEach(s => _dal.Sale.Delete(s.SaleId));

        // 5. Final Step: Delete the product itself
        try
        {
            _dal.Product.Delete(id);
        }
        catch (DO.DalIdNotFoundExceptions ex)
        {
            throw new BO.BlDoesNotExistException($"Product {id} could not be deleted because it disappeared from the system.", ex);
        }
    }


    public void GetSales(BO.ProductInOrder productInOrder, bool isClubMember)
    {
        // 1. ניקוי הרשימה הקיימת כדי שלא יצטברו מבצעים כפולים בקריאות חוזרות
        productInOrder.Sales = new List<BO.SaleInProduct>();

        // 2. שאילתת LINQ שמחפשת את המבצעים המתאימים
        var salesQuery = from sale in _dal.Sale.ReadAll()
                             // תנאי א: המבצע שייך למוצר המבוקש
                         where sale.ProdId == productInOrder.ProdId
                         // תנאי ב: המבצע בתוקף (התאריך של היום בין תאריך התחלה לסיום)
                         where DateTime.Now >= sale.StartDateSale && DateTime.Now <= sale.StopDateSale
                         // תנאי ג: הכמות בהזמנה הגיעה למינימום הנדרש במבצע
                         where productInOrder.ProdAmount >= sale.MinRequireQuantity
                         // תנאי ד: אם הלקוח לא חבר מועדון, המבצע חייב להיות פתוח לכולם
                         where isClubMember || !sale.JustForClub

                         // מיון לפי כדאיות: מחיר המבצע הנמוך ביותר קודם
                         orderby sale.PriceInSale

                         // המרה ל-BO
                         select new BO.SaleInProduct
                         {
                             SaleId = sale.SaleId,
                             AmountForSale = sale.MinRequireQuantity,
                             Price = sale.PriceInSale,
                             JustForClub = sale.JustForClub
                         };

        productInOrder.Sales = salesQuery.ToList();
    }
    //public BO.Product? Read(Func<BO.Product, bool> filter)
    //{
    //    try
    //    {

    //        DO.Product? doProduct = _dal.Product.Read(doItem => filter?.Invoke(doItem.ToBO()) ?? true);

    //        return doProduct?.ToBO();
    //    }
    //    catch (DO.DalIdNotFoundExceptions ex)
    //    {
    //        throw new BO.BlDoesNotExistException("No product was found that matches the specified condition.", ex);
    //    }
    //    catch (Exception ex)
    //    {
    //        // תפיסת שגיאות כלליות אחרות ועטיפתן בחריגת BL
    //        throw new BO.BlDoesNotExistException("An error occurred while searching for the product.", ex);
    //    }
    //}
    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        try
        {
            // 1. שליפה מה-DAL (המרת DO ל-BO לצורך בדיקת התנאי)
            DO.Product doProduct = _dal.Product.Read(doItem => filter(doItem.ToBO()));
            BO.Product boProduct = doProduct.ToBO();

            // 2. הוספת המבצעים המסודרים (בדיוק כמו ב-Read לפי ID)
            boProduct.Sales = (from sale in _dal.Sale.ReadAll(s => s.ProdId == boProduct.ProdId)
                               orderby sale.PriceInSale
                               select new BO.SaleInProduct
                               {
                                   SaleId = sale.SaleId,
                                   AmountForSale = sale.MinRequireQuantity,
                                   Price = sale.PriceInSale,
                                   JustForClub = sale.JustForClub
                               }).ToList();

            return boProduct;
        }
        catch (DO.DalIdNotFoundExceptions)
        {
            return null;
        }
    }
    public BO.Product? Read(int id)
    {
        if (id <= 0)
            throw new BO.BlInvalidInputException("מזהה מוצר חייב להיות מספר חיובי.");

        try
        {
            // 1. שליפה מה-DAL
            DO.Product doProduct = _dal.Product.Read(id);

            // 2. המרה ל-BO (הנתונים הבסיסיים)
            BO.Product boProduct = doProduct.ToBO();

            // 3. "נירמול" - השלמת רשימת המבצעים ששייכים למוצר הזה
            boProduct.Sales = (from sale in _dal.Sale.ReadAll(s => s.ProdId == id)
                               select new BO.SaleInProduct
                               {
                                   SaleId = sale.SaleId,
                                   AmountForSale = sale.MinRequireQuantity,
                                   Price = sale.PriceInSale,
                                   JustForClub = sale.JustForClub
                               }).ToList();

            return boProduct;
        }
        catch (DO.DalIdNotFoundExceptions ex)
        {
            throw new BO.BlDoesNotExistException($"מוצר עם מזהה {id} לא נמצא במערכת.", ex);
        }
    }


    //public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
    //{
    //    try
    //    {
    //        return (from DO.Product doProd in _dal.Product.ReadAll()
    //                let boProd = doProd.ToBO() // שימוש ב-let להמרה חד-פעמית ל-BO בעזרת ה-Tools
    //                where filter == null || filter(boProd) // בדיקה אם הפילטר ריק או שהאובייקט עונה לתנאי
    //                select boProd).ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        // עטיפת כל חריגה מה-DAL בחריגת BO מתאימה עם החרגה פנימית (InnerException)
    //        throw new BO.BlDoesNotExistException("Failed to retrieve products list from the system.", ex);
    //    }
    //}
    public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        try
        {
            // 1. שליפת כל המוצרים והפיכתם ל-BO
            var products = _dal.Product.ReadAll()
                .Select(doProd => doProd.ToBO())
                .Where(boProd => filter == null || filter(boProd))
                .ToList();

            // 2. לכל מוצר ברשימה - מוסיפים את המבצעים שלו מה-DAL
            products.ForEach(boProd =>
            {
                boProd.Sales = (from sale in _dal.Sale.ReadAll(s => s.ProdId == boProd.ProdId)
                                orderby sale.PriceInSale
                                select new BO.SaleInProduct
                                {
                                    SaleId = sale.SaleId,
                                    AmountForSale = sale.MinRequireQuantity,
                                    Price = sale.PriceInSale,
                                    JustForClub = sale.JustForClub
                                }).ToList();
            });

            return products;
        }
        catch (Exception ex)
        {
            throw new BO.BlDoesNotExistException("Failed to retrieve products list.", ex);
        }
    }
    public void Update(BO.Product product)
    {

        ValidateProduct(product);

        try
        {
            _dal.Product.Read(product.ProdId);
        }
        catch (DO.DalIdNotFoundExceptions ex)
        {
            throw new BO.BlDoesNotExistException($"Update failed: Product with ID {product.ProdId} does not exist in the system.", ex);
        }

        // 3. Data Transformation & DAL Update
        // We convert our Business Object (BO) to a Data Object (DO) using our Tools.
        try
        {
            DO.Product doProduct = product.ToDO();
            _dal.Product.Update(doProduct);
        }
        catch (DO.DalIdNotFoundExceptions ex)
        {
            // This is a safety net in case the product was deleted by another process 
            // between our Read and Update calls.
            throw new BO.BlDoesNotExistException($"Update failed: Product {product.ProdId} was removed during the process.", ex);
        }
    }



    private void ValidateProduct(BO.Product product)
    {
        // --- 1. Basic Product Integrity ---
        if (product == null)
            throw new BO.BlInvalidInputException("Product object cannot be null.");



        if (string.IsNullOrWhiteSpace(product.ProdName))
            throw new BO.BlInvalidInputException("Product name is required and cannot be empty.");

        if (product.Price <= 0)
            throw new BO.BlInvalidInputException("Product price must be a positive value.");

        if (product.QuantityInStock < 0)
            throw new BO.BlInvalidInputException("Stock quantity cannot be a negative value.");

        // --- 2. Sales Validation using LINQ ---
        if (product.Sales != null && product.Sales.Any())
        {
            // A. Verify that all SaleIds exist in the DAL
            // Using ToList().ForEach to allow throwing specific exceptions during iteration
            product.Sales.ToList().ForEach(sale =>
            {
                try
                {
                    // Validate existence of the SaleId in the Project's DAL
                    var dalSale = _dal.Sale.Read(sale.SaleId);

                    // B. Data Consistency: Ensure the Sale in DAL actually belongs to this Product
                    if (dalSale.ProdId != product.ProdId)
                        throw new BO.BlInvalidInputException($"Inconsistency: Sale ID {sale.SaleId} belongs to Product {dalSale.ProdId}, not {product.ProdId}.");
                }
                catch (DO.DalIdNotFoundExceptions ex)
                {
                    // Thrown if SaleId does not exist in the project
                    throw new BO.BlDoesNotExistException($"The Sale ID {sale.SaleId} provided in the product's sales list does not exist in the system.", ex);
                }
            });

            // C. Numerical Validation for Sales
            if (product.Sales.Any(s => s.AmountForSale <= 0 || s.Price <= 0))
                throw new BO.BlInvalidInputException("Sale price and minimum quantity must be positive values.");

            // D. Business Rule: Sale price must be lower than original price
            if (product.Sales.Any(s => s.Price >= product.Price))
                throw new BO.BlInvalidInputException("Business Logic Violation: Sale price must be lower than the original product price.");
        }
    }
}
