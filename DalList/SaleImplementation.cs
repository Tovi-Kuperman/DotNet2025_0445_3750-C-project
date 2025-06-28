using DO;
using DalApi;
using System.Linq;
using Tools;
using System.Reflection;
namespace Dal;

internal class SaleImplementation:ISale
{

    public int Create(Sale item)
    {//Creates new entity object in DAL
        Sale s = item with { SaleCode = DataSource.Config.CurrentSaleCode };
        DataSource.Sales.Add(s);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הוספת מבצע חדש");
        return s.SaleCode;
    }


    public Sale? Read(int id)
    {//Reads entity object by its ID 
        try
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת מבצע");
            return DataSource.Sales.Single(s => s.SaleCode == id);
        }
        catch
        {
            throw new DalIdNotFoundException("Sale not found");
        }

    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter)
    {
        //stage 1 only, Reads all entity objects
        if (filter != null)
        {
            var query = from s in DataSource.Sales where filter(s) == true select s;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת כל המבצעים");
            return query.ToList();
        }
        return new List<Sale>(DataSource.Sales);
    }
    public void Update(Sale item)
    {//Updates entity object
      Delete(item.SaleCode);
      DataSource.Sales.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "עדכון מבצע");

    }
    public void Delete(int id)
    {//Deletes an object by its Id
        Sale temp = Read(id);
        DataSource.Sales.Remove(temp);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "מחיקת מבצע");
    }

    public Sale? Read(Func<Sale, bool>? filter)
    {
        if (filter != null)
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "הצגת מבצע העומד בתנאי");
        return DataSource.Sales.FirstOrDefault(filter);
        return null;
    }
}
