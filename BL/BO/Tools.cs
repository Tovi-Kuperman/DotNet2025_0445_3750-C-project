

using System;
using System.Reflection;
using System.Text;

namespace BO;

static internal class Tools
{
    public static BO.Product Convert(DO.Product p)
    {
        return new BO.Product(p.Code, p.ProductName, p.Category, p.Price, p.AmountInStock, new List<SaleInProduct>());
    }

    public static DO.Product Convert(BO.Product p)
    {
        return new DO.Product(p.Code, p.ProductName, p.Category, p.Price, p.AmountInStock);
    }

    public static BO.Customer Convert(DO.Customer c)
    {
        return new BO.Customer(c.Id, c.Name, c.Address, c.PhoneNumber);
    }

    public static DO.Customer Convert(BO.Customer c)
    {
        return new DO.Customer(c.Id, c.Name, c.Address, c.PhoneNumber);
    }

    public static BO.Sale Convert(DO.Sale s)
    {
        return new BO.Sale(s.SaleCode,s.ProductId, s.AmountForSale, s.TotalSalePrice, s.IsForClub ,s.SaleBeginningDate , s.SaleEndDate);
    }

    public static DO.Sale Convert(BO.Sale s)
    {
        return new DO.Sale(s.SaleCode, s.ProductId, s.AmountForSale, s.TotalSalePrice, s.IsForClub, s.SaleBeginningDate, s.SaleEndDate);
    }



    //המרות מפורשות- יותר ברור וקריא בקוד

    public static BO.Customer CastCustomerDOToBO(this DO.Customer customerDO)
    {
        BO.Customer customerBO = new BO.Customer(customerDO.Id, customerDO.Name, customerDO.Address, customerDO.PhoneNumber);
        return customerBO;
    }
    public static DO.Customer CastCustomerBOToDO(this BO.Customer customerBO)
    {
        DO.Customer customerDO = new DO.Customer(customerBO.Id, customerBO.Name, customerBO.Address, customerBO.PhoneNumber);
        return customerDO;
    }

    public static DO.Product CastProductBOtoDO(this BO.Product productBO)
    {
        DO.Product productDO = new DO.Product(productBO.Code, productBO.ProductName, (DO.Categories)productBO.Category, productBO.Price, productBO.AmountInStock);
        return productDO;
    }

    public static BO.Product CastProductDOToBO(this DO.Product productDO)
    {
        return new BO.Product(productDO.Code, productDO.ProductName, productDO.Category, productDO.Price, productDO.AmountInStock, new List<SaleInProduct>());
    }

    public static BO.Sale CastSaleDOToBO(this DO.Sale saleDO)
    {
        return new BO.Sale(saleDO.SaleCode, saleDO.ProductId, saleDO.AmountForSale, saleDO.TotalSalePrice, saleDO.IsForClub, saleDO.SaleBeginningDate, saleDO.SaleEndDate);
    }

    public static DO.Sale CastSaleBOtoDO(this BO.Sale saleBO)
    {
        return new DO.Sale(saleBO.SaleCode, saleBO.ProductId, saleBO.AmountForSale, saleBO.TotalSalePrice, saleBO.IsForClub, saleBO.SaleBeginningDate, saleBO.SaleEndDate);
    }


    public static string ToStringProperty<T>(this T obj, string prefix = "", HashSet<object> printedObjects = null)
    {
        StringBuilder sb = new StringBuilder();

        if (obj == null)
            return "Object is NULL";

        if (printedObjects == null)
            printedObjects = new HashSet<object>();

        if (printedObjects.Contains(obj))
            return ""; // כבר הודפס

        printedObjects.Add(obj);

        Type t = obj.GetType();

        foreach (PropertyInfo prop in t.GetProperties())
        {
            object value = null;

            try
            {
                value = prop.GetValue(obj);
            }
            catch
            {
                sb.AppendLine($"{prefix}{prop.Name} = [Unable to read]");
                continue;
            }

            if (value == null)
            {
                sb.AppendLine($"{prefix}{prop.Name} = null");
            }
            else if (value is string || value.GetType().IsPrimitive || value is DateTime || value is Enum)
            {
                sb.AppendLine($"{prefix}{prop.Name} = {value}");
            }
            else if (value is System.Collections.IEnumerable enumerable && !(value is string))
            {
                sb.AppendLine($"{prefix}{prop.Name} = [");
                foreach (var item in enumerable)
                {
                    sb.AppendLine($"{prefix}  - {item?.ToStringProperty(prefix + "\t", printedObjects)}");
                }
                sb.AppendLine($"{prefix}]");
            }
            else
            {
                sb.AppendLine($"{prefix}{prop.Name} =");
                sb.Append(value.ToStringProperty(prefix + "\t", printedObjects));
            }
        }

        return sb.ToString();
    }
}
