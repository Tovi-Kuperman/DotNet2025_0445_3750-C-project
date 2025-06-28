using DO;
using DalApi;
using Tools;
namespace Dal
{
    internal class CustomerImplementation : ICustomer
    {

        public int Create(Customer item)
        {//Creates new entity object in DAL
            try
            {
                Read(item.Id);
                throw new DalIdAllreadyExists("Id already exists");
            }
            catch
            {
                DataSource.Customers.Add(item);
                LogManager.WriteToLog("DalList","","הוספת לקוח חדש");
                return item.Id;
            }
        }


        public Customer? Read(int id)
        {//Reads entity object by its ID 

            try
            {
                LogManager.WriteToLog("DalList", "Read", "הצגת לקוח");
                return DataSource.Customers.Single<Customer>(c => c.Id == id);
            }
            catch
            {
                throw new DalIdNotFoundException("customer doesn't exist");
            }
        }
        public List<Customer?> ReadAll(Func<Customer, bool>? filter)
        {
            //stage 1 only, Reads all entity objects
            if (filter != null)
            {
                var query = from c in DataSource.Customers where filter(c) == true select c;
                LogManager.WriteToLog("DalList", "ReadAll", "הצגת כל הלקוחות");
                return query.ToList();
            }
            return new List<Customer>(DataSource.Customers);
        }
        public void Update(Customer item)
        {
            //Updates entity object
            Delete(item.Id);
            DataSource.Customers.Add(item);
            LogManager.WriteToLog("DalList", "Update", "עדכון לקוח");

        }
        public void Delete(int id)
        {
            //Deletes an object by its Id
            Customer temp = Read(id);
            DataSource.Customers.Remove(temp);
            LogManager.WriteToLog("DalList", "Update", "מחיקת מבצע");

        }

        public Customer? Read(Func<Customer, bool>? filter)
        {
            if (filter != null)
            {
                LogManager.WriteToLog("DalList", "Read", "הצגת לקוח העומד בתנאי");
                return DataSource.Customers.FirstOrDefault(filter);
            }
            return null;
        }
    }
}
