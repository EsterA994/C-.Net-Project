using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace BL
{
    internal class CustomerImplementation: ICustomer
    {

        private readonly DalApi.IDal _dal = DalApi.Factory.Get;
        public int Create(BO.Customer item)
        {
            Console.WriteLine(item);
            // 1. שלב הוולידציה (מחוץ ל-try)
            ValidateCustomer(item);

            // 2. שלב הפנייה ל-DAL (בתוך try)
            try
            {
                // המרה באמצעות ה-Tools שלך (מ-BO ל-DO)
                DO.Customer doCustomer = item.ToDO();

                return _dal.Customer.Create(doCustomer);
            }
            catch (DalIdAlreadyExistExceptions ex)
            {
                // תרגום שגיאת ה-DAL לשגיאת BL כדי שה-UI לא יכיר את ה-DAL!
                throw new BlIdAlreadyExistExceptions($"Customer with ID {item.CustId} already exists.", ex);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new BlInvalidInputException("Invalid ID. Customer ID must be a positive number.");

            try
            {
                // 2. שלב הפנייה ל-DAL
                _dal.Customer.Delete(id);
            }
            catch (DO.DalIdNotFoundExceptions ex) // תופסים את שגיאת השכבה הנמוכה
            {
                // זורקים שגיאת BL מתאימה (למשל BlDoesNotExistException)
                throw new BO.BlDoesNotExistException($"Customer with ID {id} was not found.", ex);
            }
        }

        public bool IsExsitsCust(int id)
        {
            try
            {
                if (id <= 0)
                    throw new BlInvalidInputException("Invalid ID. Customer ID must be a positive number.");
                // מנסים לקרוא את הלקוח מה-DAL
                _dal.Customer.Read(id);
                return true; // אם הגענו לכאן, סימן שהוא קיים
            }
            catch (DalIdNotFoundExceptions) // כדאי לשנות ל- DO.DalIdNotFoundExceptions
            {
                return false;
            }
        }


        public BO.Customer? Read(Func<BO.Customer, bool> filter)
        {


            DO.Customer? doCust = _dal.Customer.Read(doItem => filter(doItem.ToBO()));

            return doCust?.ToBO();
        }

        public BO.Customer? Read(int id)
        {
            if (id <= 0)
                throw new BlInvalidInputException("Invalid ID. Customer ID must be a positive number.");

            try
            {

                DO.Customer? getCustomer = _dal.Customer.Read(id);

                return getCustomer?.ToBO();
            }
            catch (DO.DalIdNotFoundExceptions ex) // תפיסת השגיאה מה-DAL
            {
                // זריקת שגיאה של שכבת ה-BL
                throw new BO.BlDoesNotExistException($"Customer with ID {id} does not exist in the system.", ex);
            }
        }


        public List<BO.Customer> ReadAll(Func<BO.Customer, bool>? filter = null)
        {
            return (from doCust in _dal.Customer.ReadAll(doItem => filter?.Invoke(doItem.ToBO()) ?? true)
                    select doCust?.ToBO()).ToList();
        }

        public void Update(BO.Customer item)
        {
            // משתמשים בדיוק באותה פונקציית ולידציה!
            ValidateCustomer(item);

            try
            {
                DO.Customer doCustomer = item.ToDO();
                _dal.Customer.Update(doCustomer);
            }
            catch (DO.DalIdNotFoundExceptions ex) // זה הסוג הנכון לתפוס ב-Update
            {
                throw new BO.BlDoesNotExistException($"Customer with ID {item.CustId} does not exist.", ex);
            }
        }

        private void ValidateCustomer(BO.Customer item)
        {
            if (item == null)
                throw new BO.BlInvalidInputException("Customer data is missing (null).");

            if (item.CustId <= 0)
                throw new BO.BlInvalidInputException("Customer ID must be a positive number.");

            if (string.IsNullOrWhiteSpace(item.CustName))
                throw new BO.BlInvalidInputException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(item.CustAddress))
                throw new BO.BlInvalidInputException("Customer address is required.");

            if (string.IsNullOrWhiteSpace(item.CustPhone))
                throw new BO.BlInvalidInputException("Customer phone number is required.");

            if (item.CustPhone.Length < 9)
                throw new BO.BlInvalidInputException("Phone number is too short (minimum 9 digits).");

            if (!item.CustPhone.All(char.IsDigit))
                throw new BO.BlInvalidInputException("Phone number must contain digits only.");
        }

    }

}