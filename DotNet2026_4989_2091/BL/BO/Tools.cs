using System;
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

}
