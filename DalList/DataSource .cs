using System.Collections.Generic;
using DO;



namespace Dal
{
    static internal class DataSource
    {
        static internal List<Product?> Products = new List<Product?>();
        static internal List<Sale?> Sales = new List<Sale?>();
        static internal List<Customer?> Customers = new List<Customer?>();

        static internal class Config
        {
            internal const int START_SALE_CODE = 1020;
            private static int SaleCode = START_SALE_CODE;
            internal const int START_PRODUCT_CODE = 150;
            private static int ProductCode = START_PRODUCT_CODE;
            public static int CurrentSaleCode { get { return SaleCode+=10; } }

            public static int CurrentProductCode { get { return ProductCode++; } }
        }
    }
}
