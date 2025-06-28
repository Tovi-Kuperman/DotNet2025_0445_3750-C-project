using BO;
namespace BlApi;


    public interface IOrder
{
//    •	AddProductToOrder  - מתודה להוספת מוצר להזמנה – מקבלת כפרמטרים הזמנה(BO.Order), מזהה מוצר(int) וכמות להזמנה(int). מחזירה רשימת מבצעים שהתקבלו למוצר שנוסף(רשימה מסוג BO.SaleInProduct).
//•	CalcTotalPriceForProduct  - מתודה לחישוב המחיר הסופי למוצר – מקבלת כפרמטר מוצר מסוג BO.ProductInOrder ולא מחזירה ערך.
//•	CalcTotalPrice  - מתודה לחישוב המחיר הסופי להזמנה – מקבלת כפרמטר הזמנה (BO.Order) ולא מחזירה ערך
//•	DoOrder  - מתודה לביצוע הזמנה – מקבלת כפרמטר הזמנה (BO.Order) ולא מחזירה ערך.
//•	SearchSaleForProduct - עדכון המבצעים המתאימים למוצר בהזמנה - מקבלת קוד מוצר ומשתנה בוליאני לציון האם לקוח "מועדף" או לא,
//מחזירה רשימה מסוג SaleInProduct

    //List<SaleInProduct> GetProducts(Order order ,int code , int amount);
    void CalcTotalPriceForProduct(ProductInOrder productInOrder, bool IsInClub);
    void CalcTotalPrice(Order order);
    void DoOrder(Order order);
    List<SaleInProduct> SearchSalesForProduct(BO.ProductInOrder productInOrder, bool isInClub);
    List<SaleInProduct> AddProductToOrder(Order order, int code, int amount);
}

