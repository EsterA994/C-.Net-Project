using System.Collections;
using System.Reflection;
using System.Text;

namespace BO;

internal static class Tools
{

    public static string ToStringProperty<T>(this T obj)
    {
        return ToStringProperty(obj, 0);
    }

    private static string ToStringProperty(object obj, int indent)
    {
        if (obj == null)
            return "null";

        Type type = obj.GetType();

        StringBuilder sb = new StringBuilder();

        string spaces = new string(' ', indent * 4);

        sb.AppendLine($"{spaces}{type.Name}:");

        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo prop in properties)
        {
            object? value = prop.GetValue(obj);

            // null
            if (value == null)
            {
                sb.AppendLine($"{spaces}    {prop.Name}: null");
                continue;
            }

            Type valueType = value.GetType();

            // string
            if (value is string)
            {
                sb.AppendLine($"{spaces}    {prop.Name}: {value}");
            }

            // אוסף
            else if (value is IEnumerable enumerable)
            {
                sb.AppendLine($"{spaces}    {prop.Name}:");

                foreach (var item in enumerable)
                {
                    sb.AppendLine(ToStringProperty(item, indent + 2));
                }
            }

            // טיפוס פשוט
            else if (valueType.IsPrimitive ||
                     value is decimal ||
                     value is DateTime ||
                     value is Enum)
            {
                sb.AppendLine($"{spaces}    {prop.Name}: {value}");
            }

            // אובייקט פנימי
            else
            {
                sb.AppendLine($"{spaces}    {prop.Name}:");
                sb.AppendLine(ToStringProperty(value, indent + 2));
            }
        }

        return sb.ToString();
    }

    //convert?
    public static BO.Customer ToBO(this DO.Customer obj)
    {
        return new BO.Customer
        {
            CustId = obj.CustId,
            CustName = obj.CustName,
            CustAddress = obj.CustAddress,
            CustPhone = obj.CustPhone
        };
    }

    public static BO.Product ToBO(this DO.Product obj)
    {
        return new BO.Product
        {
            ProdId = obj.ProdId,
            ProdName = obj.ProdName,
            ProdCategory = (BO.ProdCategory)obj.ProdCategory,
            Price = obj.Price,
            QuantityInStock = obj.QuantityInStock,
            Sales = new List<BO.SaleInProduct>()

        };
    }
    public static BO.Sale ToBO(this DO.Sale obj)
    {
        return new BO.Sale
        {
            SaleId = obj.SaleId,
            ProdId = obj.ProdId,
            MinRequireQuantity = obj.MinRequireQuantity,
            PriceInSale = obj.PriceInSale,
            JustForClub = obj.JustForClub,
            StartDateSale = obj.StartDateSale,
            StopDateSale = obj.StopDateSale

        };
    }
    public static DO.Customer ToDO(this BO.Customer obj)
    {
        return new DO.Customer
        {
            CustId = obj.CustId,
            CustName = obj.CustName,
            CustAddress = obj.CustAddress,
            CustPhone = obj.CustPhone,

        };
    }
    public static DO.Product ToDO(this BO.Product obj)
    {
        return new DO.Product
        {
            ProdId = obj.ProdId,
            ProdName = obj.ProdName,
            ProdCategory = (DO.ProdCategory)obj.ProdCategory,
            Price = obj.Price,
            QuantityInStock = obj.QuantityInStock



        };
    }

    public static DO.Sale ToDO(this BO.Sale obj)
    {
        return new DO.Sale
        {
            SaleId = obj.SaleId,
            ProdId = obj.ProdId,
            MinRequireQuantity = obj.MinRequireQuantity,
            PriceInSale = obj.PriceInSale,
            JustForClub = obj.JustForClub,
            StartDateSale = obj.StartDateSale,
            StopDateSale = obj.StopDateSale


        };
    }

    public static BO.SaleInProduct ToSaleInProduct(this DO.Sale obj)
    {
        return new BO.SaleInProduct
        {
            SaleId = obj.SaleId,
            AmountForSale = obj.MinRequireQuantity,
            Price = obj.PriceInSale,
            JustForClub = obj.JustForClub
        };
    }
}
