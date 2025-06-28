using DalApi;
using DO;
using System.Reflection;
using System.Xml.Serialization;
using Tools;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    static object lockObject = new object();

    private List<Customer> Deserialize()
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start deserialize in customer");
        try
        {
            List<Customer> listCustomers;
            XmlSerializer serializerList = new XmlSerializer(typeof(List<Customer>));
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/customers.xml", FileMode.Open, FileAccess.Read))
                {
                    listCustomers = serializerList.Deserialize(fs) as List<Customer>;
                }
            }
            if (listCustomers == null)
            {
                listCustomers = new List<Customer>();
                 
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end deserialize in customer");
            return listCustomers;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");
            throw new DalReadFromXmlExeption("Customer");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    private void Serialize(List<Customer> listCustomer)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start serialize in customer");
        try
        {
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/customers.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializerList = new XmlSerializer(typeof(List<Customer>));
                    serializerList.Serialize(fs, listCustomer);
                }
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end serialize in customer");
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalWriteToXmlExeption("Customer");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
    public int Create(Customer item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start create in customer {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption("Customer");
            List<Customer> listCustomer = Deserialize();

            bool b = listCustomer.Any(c => c.Id == item.Id);
            if (b)
                throw new DalIdAllreadyExists("Customer");
            listCustomer.Add(item);
            Serialize(listCustomer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end create in customer {item.ToString()}");
            return item.Id;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Customer", "create in xml");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start delete in customer {id.ToString()}");
        try
        {
            List<Customer> listCustomer = Deserialize();
            Customer? c = Read(id);
            if (c == null)
                throw new DalNullObjectExeption("Customer");
            listCustomer.Remove(c);
            Serialize(listCustomer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end delete in customer {id.ToString()}");
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");
            throw new DalGeneralExeption("Customer", "delete in xml");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Customer? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in customer");
        try
        {
            List<Customer> listCustomer = Deserialize();
            Customer? customer = listCustomer.SingleOrDefault(c => c.Id == id);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in customer");
            return customer;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Customer", "read");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Customer? Read(Func<Customer, bool>? filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read (with filter) in customer");
        try
        {
            List<Customer> listCustomer = Deserialize();
            //Serialize(listCustomer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read (with filter) in customer");
            return listCustomer.SingleOrDefault(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Customer", "read in xml");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in customer");
        try
        {
            List<Customer> listCustomer = Deserialize();
            //Serialize(listCustomer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in customer");
            if (filter == null) return listCustomer;
            return listCustomer.FindAll(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Customer", "ReadAll in xml");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Customer item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start update in customer {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption("Customer");
            Delete(item.Id);
            List<Customer> listCustomer = Deserialize();
            listCustomer.Add(item);
            Serialize(listCustomer);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end update in customer {item.ToString()}");
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Customer", "update in xml");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}
