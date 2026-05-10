
using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
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
            // --- Basic Validation ---
            if (id <= 0)
                throw new BO.BlInvalidInputException("Invalid product ID. ID must be a positive number.");

            try
            {
                // --- Business Logic: Check Orders using LINQ Query Syntax ---
                var allOrderItems = _dal.OrderItem.ReadAll();
                var productInOrders = from oi in allOrderItems
                                      where oi.ProdId == id
                                      select oi;

                if (productInOrders.Any())
                {
                    throw new BO.BlDeletionImpossibleException($"Cannot delete product {id} because it is linked to existing orders.");
                }

                // --- Business Logic: Check Active Sales using LINQ Query Syntax ---
                DateTime now = DateTime.Now;
                var allSales = _dal.Sale.ReadAll();
                var activeSales = from s in allSales
                                  where s.ProdId == id
                                  where s.StartDateSale <= now
                                  where (s.StopDateSale == null || s.StopDateSale >= now)
                                  select s;

                if (activeSales.Any())
                {
                    throw new BlDeletionImpossibleException($"Cannot delete product {id} because there is an active sale currently running.");
                }

                // --- Execution ---
                _dal.Product.Delete(id);
            }
            catch (DO.DalIdNotFoundExceptions ex)
            {
                throw new BO.BlDoesNotExistException($"Product with ID {id} was not found in the database.", ex);
            }
        }

        public void GetSales(ProductInOrder productInOrder, bool isClubMember)
        {
            throw new NotImplementedException();
        }

        public BO.Product? Read(Func<BO.Product, bool> filter)
        {
            try
            {
                
                DO.Product? doProduct = _dal.Product.Read(doItem => filter?.Invoke(doItem.ToBO()) ?? true);

                return doProduct?.ToBO();
            }
            catch (DO.DalIdNotFoundExceptions ex)
            {
                throw new BO.BlDoesNotExistException("No product was found that matches the specified condition.", ex);
            }
            catch (Exception ex)
            {
                // תפיסת שגיאות כלליות אחרות ועטיפתן בחריגת BL
                throw new BO.BlDoesNotExistException("An error occurred while searching for the product.", ex);
            }
        }
        public BO.Product? Read(int id)
        {
            if (id <= 0)
                throw new BO.BlInvalidInputException("מזהה מוצר חייב להיות מספר חיובי.");

            try
            {
                // שליפה מה-DAL והמרה ל-BO באמצעות ה-Tools
                DO.Product doProduct = _dal.Product.Read(id);
                return doProduct?.ToBO();
            }
            catch (DO.DalIdNotFoundExceptions ex)
            {
                // עטיפת החריגה כחריגת BO
                throw new BO.BlDoesNotExistException($"מוצר עם מזהה {id} לא נמצא במערכת.", ex);
            }
        }

        public List<BO.Product> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            try
            {
                return (from DO.Product doProd in _dal.Product.ReadAll()
                        let boProd = doProd.ToBO() // שימוש ב-let להמרה חד-פעמית ל-BO בעזרת ה-Tools
                        where filter == null || filter(boProd) // בדיקה אם הפילטר ריק או שהאובייקט עונה לתנאי
                        select boProd).ToList();
            }
            catch (Exception ex)
            {
                // עטיפת כל חריגה מה-DAL בחריגת BO מתאימה עם החרגה פנימית (InnerException)
                throw new BO.BlDoesNotExistException("Failed to retrieve products list from the system.", ex);
            }
        }
        public void Update(BO.Product item)
        {

            ValidateProduct(item);

            try
            {
                DO.Product doProduct = item.ToDO();

                // 3. פנייה ל-DAL לביצוע העדכון
                _dal.Product.Update(doProduct);
            }
            catch (DO.DalIdNotFoundExceptions ex) 
            {
               
                throw new BO.BlDoesNotExistException($"Product with ID {item.ProdId} does not exist and cannot be updated.", ex);
            }
        }

        private void ValidateProduct(BO.Product item)
        {
            // בדיקה שהאובייקט אינו null
            if (item == null)
                throw new BO.BlInvalidInputException("Product data is missing.");

            // בדיקת מזהה (חייב להיות חיובי)
            if (item.ProdId <= 0)
                throw new BO.BlInvalidInputException("Product ID must be a positive number.");

            // בדיקת שם מוצר - לא יכול להיות ריק או רק רווחים
            if (string.IsNullOrWhiteSpace(item.ProdName))
                throw new BO.BlInvalidInputException("Product name cannot be empty.");

            // בדיקת מחיר - מחיר חייב להיות חיובי
            if (item.Price <= 0)
                throw new BO.BlInvalidInputException("Product price must be greater than zero.");

            // בדיקת מלאי - כמות במלאי לא יכולה להיות שלילית
            if (item.QuantityInStock < 0)
                throw new BO.BlInvalidInputException("Quantity in stock cannot be negative.");
        }
    }
}
