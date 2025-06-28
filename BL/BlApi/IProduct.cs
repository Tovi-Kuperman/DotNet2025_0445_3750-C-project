using BO;

namespace BlApi;

public interface IProduct
{

    int Create(Product item); //Creates new entity object in DAL
    Product? Read(int id); //Reads entity object by its ID 
    Product? Read(Func<Product, bool>? filter);// Reads entity object by some parameter
    List<Product?> ReadAll(Func<Product, bool>? filter = null); //stage 1 only, Reads all entity objects
    void Update(Product item); //Updates entity object
    void Delete(int id); //Deletes an object by its Id

    //בתוספת מתודה לקבלת כל המבצעים שבתוקף של המוצר (מקבלת קוד מוצר ומשתנה בוליאני לציון האם לקוח "מועדף" או לא), מחזירה רשימה מסוג SaleInProduct
    List<SaleInProduct> GetActiveSales(int code, bool isInClub, int amount);
}
