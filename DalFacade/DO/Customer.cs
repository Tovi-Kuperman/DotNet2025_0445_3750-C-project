using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// ישות לקוח המכילה את התכונות הבאות:
    /// תעודת זהות
    /// שם הלקוח
    /// כתובת
    /// טלפון
    /// </summary>
    public record Customer
        (int Id,
        string? Name,
        string? Address,
        string? PhoneNumber
        )
    {

        public Customer() : this(0, "", "", "")
        {

        }
    }
}


