using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    /// <summary>
    /// ישות מוצר המכילה את התכונות הבאות:
    /// מספר מזהה ייחודי
    /// שם המוצר
    /// קטגוריה
    /// מחיר
    /// כמות במלאי
    /// </summary>
    public record Product
        (int Code,
        string? ProductName,
        Categories? Category,
        double? Price,
        int? AmountInStock
        )
    { 
        public Product():this(0,"",0,0,0)
        {

        }

    }
}
