using DO;
using DalApi;
using System.Collections.Generic;
using Tools;
using System.Reflection;
namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        public int Create(Product item)
        {
            Product p = item with { Code = DataSource.Config.CurrentProductCode };
            DataSource.Products.Add(p);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הוספת מוצר חדש");

            return p.Code;
        }


        public Product? Read(int id)
        {//Reads entity object by its ID 

            try
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת מוצר");
                return DataSource.Products.Single(p => p.Code == id);
            }
            catch
            {
                throw new DalIdNotFoundException("Product not found");
            }
        }

        public void Update(Product item)
        {//Updates entity object
            Delete(item.Code);
            DataSource.Products.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "עדכון מוצר");

        }
        public void Delete(int id)
        {//Deletes an object by its Id
            Product temp = Read(id);
            DataSource.Products.Remove(temp);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "מחיקת מוצר");

        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            if (filter != null)
            {
                var query = from p in DataSource.Products where filter(p) == true select p;
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת כל המוצרים");

                return query.ToList();

            }
            return new List<Product>(DataSource.Products);

        }

        public Product? Read(Func<Product, bool>? filter)
        {
            if (filter != null)
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת מוצר העומד בתנאי");

            return DataSource.Products.FirstOrDefault(filter);
            return null;
        }
    }
}
