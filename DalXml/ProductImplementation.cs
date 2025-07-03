using DalApi;
using DO;
using System.Reflection;
using System.Xml.Serialization;
using Tools;


namespace Dal;

internal class ProductImplementation: IProduct
{
    static object lockObject = new object();


    private List<Product> Deserialize()
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start deserialize in product");
        try
        {
            List<Product> listProducts;
            XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Open, FileAccess.Read))
                {
                    listProducts = serializerList.Deserialize(fs) as List<Product>;
                }
            }
            if (listProducts == null)
            {
                listProducts = new List<Product>();
                LogManager.WriteToLog("הרשימה של המוצרים נאל", "!", "--------------------------");

            }
            LogManager.WriteToLog("הרשימה של המוצרים לא נאל", "!", "--------------------------");
            return listProducts;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalReadFromXmlExeption("Product");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end deserialize in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    private void Serialize(List<Product> listProduct)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start serialize in product");
        try
        {
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
                    serializerList.Serialize(fs, listProduct);
                }
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalWriteToXmlExeption("Product");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end serialize in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public int Create(Product item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create in product");
        try
        {
            if (item == null) throw new DalNullObjectExeption("Product");
            List<Product> listProduct = Deserialize();


            Product p = item with { Code = Config.CodeProduct };
            bool b = listProduct.Any(c => c.Code == item.Code);
            if (b)
            {
                throw new DalIdAllreadyExists("Product");
            }
            listProduct.Add(p);
            Serialize(listProduct);
            return p.Code;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");
            throw new DalGeneralExeption("Product", "create");

        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end create in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);

        }

    }

    public Product? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in product");
        try
        {
            List<Product> listProduct = Deserialize();
            Product Product = listProduct.SingleOrDefault(c => c.Code == id);
            return Product;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "read");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Product item)
    {
        //Updates entity object
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start update in product {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption("Product");
            Delete(item.Code);
            List<Product> listProduct = Deserialize();
            listProduct.Add(item);
            Serialize(listProduct);
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "update");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end update in product {item.ToString()}");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start delete in product {id.ToString()}");
        try
        {
            List<Product> listProduct = Deserialize();
            int prodId = listProduct.RemoveAll(prod => prod.Code == id);
            if (prodId == 0)
            {
                throw new DalIdNotExistExeption("Product");
            }
            Serialize(listProduct);
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "delete");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end delete in product {id.ToString()}");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Product? Read(Func<Product, bool>? filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read with filter in product");
        try
        {
            List<Product> listProduct = Deserialize();
            return listProduct.SingleOrDefault(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "read");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read with filter in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in product");
        try
        {
            List<Product> listProduct = Deserialize() ?? new List<Product>();
            if (filter == null) return listProduct;
            LogManager.WriteToLog("listProduct: ", listProduct.Count.ToString(), "TYH!!!");

            return listProduct.FindAll(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "readAll");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}
