using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale item)
        {
            // 1. שלב הוולידציה (מחוץ ל-try) - בדיקה עסקית לפני פנייה לנתונים
            ValidateSale(item);

            // 2. שלב הפנייה ל-DAL (בתוך try)
            try
            {
                // המרה באמצעות ה-Tools (מ-BO ל-DO)
                DO.Sale doSale = item.ToDO();

                // שליחה ל-DAL - שימי לב שבמימוש ה-DAL שלך הפונקציה מחזירה את ProdId
                return _dal.Sale.Create(doSale);
            }
            catch (DO.DalIdAlreadyExistExceptions ex) // תפיסת חריגת השכבה הנמוכה
            {
                // תרגום לשגיאת BL עם החריגה המקורית כ-InnerException
                throw new BO.BlIdAlreadyExistExceptions($"Sale with ID {item.SaleId} already exists.", ex);
            }
        }

        // מתודת עזר לוולידציה לפי המבנה של Customer
        public void Delete(int id)
        {
            // 1. שלב הוולידציה - בדיקה שהמזהה תקין (חיובי) לפני פנייה ל-DAL
            if (id <= 0)
                throw new BO.BlInvalidInputException("Invalid ID. Sale ID must be a positive number.");

            try
            {
                // 2. שלב הפנייה ל-DAL לביצוע המחיקה
                _dal.Sale.Delete(id);
            }
            catch (DO.DalIdNotFoundExceptions ex) // תפיסת חריגת ה-DAL במידה והמזהה לא קיים
            {
                // 3. עטיפת החריגה בחריגת BL ושליחתה עם ה-InnerException המקורי
                throw new BO.BlDoesNotExistException($"Sale with ID {id} was not found.", ex);
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            try
            {
                // כאן משתמשים במתודת הרחבה ולמבדה
                DO.Sale? doSale = _dal.Sale.Read(doItem => filter?.Invoke(doItem.ToBO()) ?? true);

                return doSale?.ToBO();
            }
            catch (Exception ex)
            {
                throw new BO.BlDoesNotExistException("Error reading specific sale by filter.", ex);
            }
        }

        public BO.Sale? Read(int id)
        {
            // 1. שלב הוולידציה - בדיקת תקינות הקלט לפני פנייה ל-DAL
            if (id <= 0)
                throw new BO.BlInvalidInputException("Invalid ID. Sale ID must be a positive number.");

            try
            {
                // 2. שלב הפנייה ל-DAL - קבלת ישות נתונים (DO)
                DO.Sale? getSale = _dal.Sale.Read(id);

                // 3. המרה לישות לוגית (BO) והחזרה
                // שימוש במתודת ההרחבה ToBO() מתוך קובץ ה-Tools
                return getSale?.ToBO();
            }
            catch (DO.DalIdNotFoundExceptions ex) // תפיסת השגיאה משכבת הנתונים
            {
                // 4. זריקת שגיאה של שכבת ה-BL עם השגיאה המקורית כ-InnerException
                throw new BO.BlDoesNotExistException($"Sale with ID {id} does not exist in the system.", ex);
            }
        }

        public List<BO.Sale> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                // שימוש בתחביר שאילתות (Query Syntax) - חובה לפי הדרישות!
                return (from DO.Sale doSale in _dal.Sale.ReadAll()
                        let boSale = doSale.ToBO() // שימוש ב-let להמרה חד פעמית
                        where filter?.Invoke(boSale) ?? true // טיפול ב-null: אם אין פילטר, הכל עובר
                        select boSale).ToList();
            }
            catch (Exception ex)
            {
                // תמיד לעטוף חריגת DAL בחריגת BO
                throw new BO.BlDoesNotExistException("Failed to retrieve sales list.", ex);
            }
        }
        public void Update(BO.Sale item)
        {
            // 1. שלב הוולידציה (מחוץ ל-try)
            // כולל בדיקת נתונים בסיסית ובדיקת קיום המוצר (ProdId) ב-DAL
            ValidateSale(item);

            try
            {
                // 2. המרה לישות נתונים (DO) באמצעות ה-Tools
                DO.Sale doSale = item.ToDO();

                // 3. פנייה ל-DAL לביצוע העדכון
                _dal.Sale.Update(doSale);
            }
            catch (DO.DalIdNotFoundExceptions ex) // תפיסת שגיאה אם המכירה עצמה לא קיימת
            {
                // 4. עטיפה בחריגת BL ושליחה עם ה-InnerException המקורי
                throw new BO.BlDoesNotExistException($"Sale with ID {item.SaleId} does not exist and cannot be updated.", ex);
            }
        }
        private void ValidateSale(BO.Sale item)
        {
            if (item == null)
                throw new BO.BlInvalidInputException("Sale data is missing (null).");

            if (item.ProdId <= 0)
                throw new BO.BlInvalidInputException("Product ID must be a positive number.");

            // --- התוספת הנדרשת: בדיקת קיום המוצר ב-DAL ---
            try
            {
                _dal.Product.Read(item.ProdId);
            }
            catch (DO.DalIdNotFoundExceptions ex) // שימוש בשגיאה מהקובץ שהעלית
            {
                throw new BO.BlDoesNotExistException($"Cannot create/update sale: Product {item.ProdId} does not exist.", ex);
            }
            // ------------------------------------------

            if (item.PriceInSale <= 0)
                throw new BO.BlInvalidInputException("Sale price must be greater than zero.");

            if (item.MinRequireQuantity <= 0)
                throw new BO.BlInvalidInputException("Minimum quantity must be at least 1.");

            if (item.StartDateSale.HasValue && item.StopDateSale.HasValue)
            {
                if (item.StopDateSale < item.StartDateSale)
                    throw new BO.BlInvalidInputException("Sale end date cannot be earlier than start date.");
            }
        }

    }
}

