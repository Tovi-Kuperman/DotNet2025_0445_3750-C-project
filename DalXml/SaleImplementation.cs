using DalApi;
using DO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Tools;

namespace Dal;

internal class SaleImplementation : ISale
{

    private const string FILE_PATH = "../xml/sales.xml";
    private const string SALE_CODE = "SaleCode";
    private const string PRODUCT_ID = "ProductId";
    private const string AMOUNT_FOR_SALE = "AmountForSale";
    private const string TOTAL_SALE_PRICE = "TotalSalePrice";
    private const string IS_FOR_CLUB = "IsForClub";
    private const string SALE_BEGIN_DATE = "SaleBeginningDate";
    private const string SALE_END_DATE = "SaleEndDate";
    private const string CLASS = "Sale";

    public int Create(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start create in sale {item.ToString()}");
        try
        {
            if (item == null) throw new DalNullObjectExeption(CLASS);
            XElement saleXml = XElement.Load(FILE_PATH);
            Sale s = item with { SaleCode = Config.CodeSale };
            saleXml.Add(new XElement(CLASS,
                         new XElement(SALE_CODE, s.SaleCode),
                         new XElement(PRODUCT_ID, s.ProductId),
                         new XElement(AMOUNT_FOR_SALE, s.AmountForSale),
                         new XElement(TOTAL_SALE_PRICE, s.TotalSalePrice),
                         new XElement(IS_FOR_CLUB, s.IsForClub),
                         new XElement(SALE_BEGIN_DATE, s.SaleBeginningDate),
                         new XElement(SALE_END_DATE, s.SaleEndDate)
                ));
            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end create in sale {item.ToString()}");
            return s.SaleCode;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "create");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start delete in sale {id.ToString()}");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var saletTempXml = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(SALE_CODE).Value) == id);
            if (saletTempXml == null) { throw new DalIdNotExistExeption(CLASS); }
            saletTempXml.Remove();
            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end delete in sale {id.ToString()}");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "delete");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(SALE_CODE).Value) == id);
            if (element == null) { throw new DalIdNotExistExeption(CLASS); }
            Sale sale = new Sale()
            {
                SaleCode = int.Parse(element.Element(SALE_CODE).Value),
                ProductId = int.Parse(element.Element(PRODUCT_ID).Value),
                AmountForSale = int.Parse(element.Element(AMOUNT_FOR_SALE).Value),
                TotalSalePrice = int.Parse(element.Element(TOTAL_SALE_PRICE).Value),
                IsForClub = bool.Parse(element.Element(IS_FOR_CLUB).Value),
                SaleBeginningDate = DateTime.Parse(element.Element(SALE_BEGIN_DATE).Value),
                SaleEndDate = DateTime.Parse(element.Element(SALE_END_DATE).Value)
            };
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in sale");
            return sale;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "read");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(Func<Sale, bool>? filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read with filter in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).Single(s => filter(
                new Sale()
                {
                    SaleCode = int.Parse(s.Element(SALE_CODE).Value),
                    ProductId = int.Parse(s.Element(PRODUCT_ID).Value),
                    AmountForSale = int.Parse(s.Element(AMOUNT_FOR_SALE).Value),
                    TotalSalePrice = int.Parse(s.Element(TOTAL_SALE_PRICE).Value),
                    IsForClub = bool.Parse(s.Element(IS_FOR_CLUB).Value),
                    SaleBeginningDate = DateTime.Parse(s.Element(SALE_BEGIN_DATE).Value),
                    SaleEndDate = DateTime.Parse(s.Element(SALE_END_DATE).Value)
                }));
            if (element == null)
            {
                throw new DalIdNotExistExeption(CLASS);
            }
            Sale sale = new Sale()
            {
                SaleCode = int.Parse(element.Element(SALE_CODE).Value),
                ProductId = int.Parse(element.Element(PRODUCT_ID).Value),
                AmountForSale = int.Parse(element.Element(AMOUNT_FOR_SALE).Value),
                TotalSalePrice = int.Parse(element.Element(TOTAL_SALE_PRICE).Value),
                IsForClub = bool.Parse(element.Element(IS_FOR_CLUB).Value),
                SaleBeginningDate = DateTime.Parse(element.Element(SALE_BEGIN_DATE).Value),
                SaleEndDate = DateTime.Parse(element.Element(SALE_END_DATE).Value)
            };
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read with filter in sale");
            return sale;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "read");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            List<Sale> resultList = saleXml.Elements(CLASS).Select(s =>
                new Sale()
                {
                    SaleCode = int.Parse(s.Element(SALE_CODE).Value),
                    ProductId = int.Parse(s.Element(PRODUCT_ID).Value),
                    AmountForSale = int.Parse(s.Element(AMOUNT_FOR_SALE).Value),
                    TotalSalePrice = int.Parse(s.Element(TOTAL_SALE_PRICE).Value),
                    IsForClub = bool.Parse(s.Element(IS_FOR_CLUB).Value),
                    SaleBeginningDate = DateTime.Parse(s.Element(SALE_BEGIN_DATE).Value),
                    SaleEndDate = DateTime.Parse(s.Element(SALE_END_DATE).Value)
                })
                .Where(filter ?? (_ => true)) // בדיקה שהפילטר לא `null`
                .ToList();
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in sale");
            return resultList;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "readAll");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start update in sale {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption(CLASS);
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(SALE_CODE).Value) == item.SaleCode);
            if (element == null) { throw new DalIdNotExistExeption(CLASS); }

            element.Element(SALE_CODE).SetValue(item.SaleCode);
            element.Element(PRODUCT_ID).SetValue(item.ProductId);
            element.Element(AMOUNT_FOR_SALE).SetValue(item.AmountForSale);
            element.Element(TOTAL_SALE_PRICE).SetValue(item.TotalSalePrice);
            element.Element(IS_FOR_CLUB).SetValue(item.IsForClub);
            element.Element(SALE_BEGIN_DATE).SetValue(item.SaleBeginningDate);
            element.Element(SALE_END_DATE).SetValue(item.SaleEndDate);

            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end update in sale {item.ToString()}");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "update");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}
