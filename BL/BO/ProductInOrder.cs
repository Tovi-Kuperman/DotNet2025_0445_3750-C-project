

namespace BO
{
    public class ProductInOrder
    {
      

        ///<summary>
        ///	מזהה מוצר (int)
        ///	שם מוצר(string)
        ///מחיר בסיס למוצר(double)
        ///כמות בהזמנה(int)
        ///רשימת מבצעים למוצר זה(רשימה של BO.SaleInProduct)
        ///מחיר סופי למוצר(double)
        /// </summary>

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductBasePrice { get; set; }
        public int AmountInOrder { get; set; }
        public List<SaleInProduct> SaleInThisProductList { get; set; }
        public double ProductTotalPrice { get; set; }

        public ProductInOrder(int productId, string productName, double productBasePrice, int amountInOrder, List<SaleInProduct> saleInThisProductList, double productTotalPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductBasePrice = productBasePrice;
            AmountInOrder = amountInOrder;
            SaleInThisProductList = saleInThisProductList;
            ProductTotalPrice = productTotalPrice;
        }
    }
}
