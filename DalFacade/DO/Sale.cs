

namespace DO;

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
public record Sale
    (int SaleCode,
    int? ProductId,
    int? AmountForSale,
    double? TotalSalePrice,
    bool? IsForClub,
    DateTime? SaleBeginningDate,
    DateTime? SaleEndDate
    )
{

    public Sale():this(0,0,0,0,false,null, null)
    {

    }
}

