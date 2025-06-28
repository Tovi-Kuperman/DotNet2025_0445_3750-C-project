

namespace BO
{
    public class SaleInProduct
    {
        ///<summary>
        ///	מזהה מבצע (int)
        /// כמות למבצע(int)
        /// מחיר(double)
        /// האם המבצע מיועד לכל הלקוחות(bool)
        /// </summary>
        /// 

        public int SaleId { get; set; }
        public int AmountForSale { get; set; }
        public double SalePrice { get; set; }
        public bool IsForAllCustomers { get; set; }
        public SaleInProduct(int saleId, int amountForSale, double salePrice, bool isForAllCustomers)
        {
            SaleId = saleId;
            AmountForSale = amountForSale;
            SalePrice = salePrice;
            IsForAllCustomers = isForAllCustomers;
        }

    }
}
