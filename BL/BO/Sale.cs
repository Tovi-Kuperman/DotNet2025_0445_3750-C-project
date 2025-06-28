
namespace BO;

public class Sale
{
   
    /// <summary>
    /// ישות מבצע המכילה את התכונות הבאות:
    /// מספר מזהה ייחודי- מספר רץ אוטומטי
    /// מספר מזהה של המוצר
    /// כמות נדרשת לקבלת המבצע  
    /// מחיר כולל במבצע
    /// האם המבצע מיועד לכלל הלקוחות או רק ללקוחות מועדון
    /// תאריך תחילת המבצע 
    /// תאריך סיום המבצע
    /// </summary>
    public  int SaleCode {get; set;}
    public  int? ProductId {get; set;}
    public  int? AmountForSale {get; set;}
    public  double? TotalSalePrice {get; set;}
    public  bool? IsForClub {get; set;}
    public  DateTime? SaleBeginningDate {get; set;}
    public  DateTime? SaleEndDate {get; set;}

    public Sale(int saleCode, int? productId, int? amountForSale, double? totalSalePrice, bool? isForClub, DateTime? saleBeginningDate, DateTime? saleEndDate)
    {
        SaleCode = saleCode;
        ProductId = productId;
        AmountForSale = amountForSale;
        TotalSalePrice = totalSalePrice;
        IsForClub = isForClub;
        SaleBeginningDate = saleBeginningDate;
        SaleEndDate = saleEndDate;
    }

}
