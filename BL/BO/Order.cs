

namespace BO
{
    public class Order
    {

        ///<summerize>
        ///
        ///האם זו הזמנה של לקוח "מועדף" או לקוח מזדמן(bool)
        ///רשימת המוצרים בהזמנה(רשימה של BO.ProductInOrder)
        ///המחיר הסופי לתשלום(double)
        ///
        ///</summerize>


        public bool IsInClub {  get; set; }
        public List<ProductInOrder> ProductInOrderList { get; set; }
        public double TotalPrice { get; set; }


        public Order(bool isInClub, List<ProductInOrder> productInOrderList, double totalPrice)
        {
            IsInClub = isInClub;
            ProductInOrderList = productInOrderList;
            TotalPrice = totalPrice;
        }
    }
}
