using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO.;
namespace BL
{
    internal class CustomerIImplementationation : ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public int Create(BO.Customer item)
        {
            ValidateCustomerFields(item);

            // 2. שלב הפנייה ל-DAL - כאן תופסים רק שגיאות שנובעות מהשכבה שמתחת
            try
            {
                // המרה באמצעות ה-Tools שלך (מ-BO ל-DO)
                DO.Customer doCustomer = item.ToDO();
                return _dal.Customer.Create(doCustomer);
            }
            catch (Exception ex)
            {
                // עטיפת חריגת ה-DAL בתוך חריגת BL והמשך זריקה למעלה
                throw new BO.BlIdAlreadyExistsException($"Creation failed: Customer with ID {item.CustId} already exists.", ex);
            }
        }

        /// <summary>
        /// Internal validation method for all edge cases of a customer.
        /// These exceptions are thrown directly to the PL.
        /// </summary>
        private void ValidateCustomerFields(BO.Customer item)
        {
            // מקרה קצה: אובייקט ריק
            if (item == null)
                throw new BO.BlInvalidInputException("Customer data is missing (null).");

            // מקרה קצה: מזהה לא תקין
            if (item.CustId <= 0)
                throw new BO.BlInvalidInputException("Customer ID must be a positive number.");

            // מקרה קצה: שם ריק או רק רווחים
            if (string.IsNullOrWhiteSpace(item.CustName))
                throw new BO.BlInvalidInputException("Customer name is required.");

            // מקרה קצה: כתובת ריקה
            if (string.IsNullOrWhiteSpace(item.CustAddress))
                throw new BO.BlInvalidInputException("Customer address is required.");

            // מקרה קצה: טלפון - בדיקת אורך ותוכן (רק ספרות)
            if (string.IsNullOrWhiteSpace(item.CustPhone))
                throw new BO.BlInvalidInputException("Customer phone number is required.");

            if (item.CustPhone.Length < 9)
                throw new BO.BlInvalidInputException("Phone number is too short (minimum 9 digits).");

            if (!item.CustPhone.All(char.IsDigit))
                throw new BO.BlInvalidInputException("Phone number must contain digits only.");

            // כאן ניתן להוסיף בדיקות נוספות כמו תקינות פורמט אימייל וכדומה
        }

        public void Delete(int id)
        {
            throw new NotIImplementationedException();
        }

        public bool IsExsitsCust(int id)
        {
            throw new NotIImplementationedException();
        }

        public Customer? Read(Func<Customer, bool> filter)
        {
          DO.Customer customer = _dal.Customer.Read(c => c.Cus);
            return 
        }

        public Customer? Read(int id)
        {
            throw new NotIImplementationedException();
        }

        public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
        {
            throw new NotIImplementationedException();
        }

        public void Update(Customer item)
        {
            throw new NotIImplementationedException();
        }
    }
}
