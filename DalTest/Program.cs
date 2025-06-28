using DalApi;
using Dal;
using DO;
using Tools;
using System.Diagnostics;
using System.Reflection;

namespace DalTest
{

    //TODO:while in the CrudMenu
    internal class Program
    {
        private static IDal? s_dal = DalApi.Factory.Get;
        private static void Main(string[] args)
        {
            try
            {
                Initialization.intialize();
                Program.MainMenu();
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }//finishes
        private static string TranselateType(string type)
        {
            //switch (type) {
            //    case "product":
            return type;
                    
        }
        private static void crudMenu<T>(string type,ICrud<T> currentReferance)
        {
            string typeH = TranselateType(type);
            Console.WriteLine("מה ברצונך לעשות?");
            Console.WriteLine($"ליצירת {type} הקש 1,\n להצגת {type} הקש 2,\n לעדכון {type} הקש 3,\n למחיקת {type} הקש 4,\n להצגת כל האובייקטים מסוג {type} הקש 5 \n לחזרה לתפריט הקודם הקש 0"
);
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            while (choice != 0)
            {
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        Create(currentReferance);
                        break;
                    case 2:
                        Read<T>(currentReferance);
                        break;
                    case 3:
                        Update(currentReferance);
                        break;
                    case 4:
                        Console.WriteLine("הכנס מזהה לחיפוש");
                        Delete(currentReferance);
                        break;
                    case 5:
                        ReadAll(currentReferance);
                        break;
                    case 6:
                        LogManager.DeleteLog();
                        break;
                }
            }
        }

        //private static object Read<T>()
        //{
        //    return Read<T>();
        //}

        private static void Create<T>(ICrud<T> currentReferance)
        {
            //ICrud<T> item = new ;
            ////get all properties from user
            ////initialize item
            //currentReferance.Create(item);
            if (currentReferance != null)
            {
                if (currentReferance is IProduct)
                {
                    try
                    {
                        s_dal.Product.Create(CreateProduct());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
                if (currentReferance is ICustomer)
                {

                    try
                    {
                        s_dal.Customer.Create(CreateCustomer());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
                if (currentReferance is ISale)
                {
                    try
                    {
                        s_dal.Sale.Create(CreateSale());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }

        private static Sale CreateSale()
        {
            Console.WriteLine("אנא הכנס את הנתונים הבאים:");
            Console.WriteLine("קוד המוצר:");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("כמות מינימלית:");
            int quantityForSale;
            int.TryParse(Console.ReadLine(), out quantityForSale);
            Console.WriteLine("מחיר מבצע:");
            int salePrice;
            int.TryParse(Console.ReadLine(), out salePrice);
            Console.WriteLine("האם למועדון:");
            bool isClub;
            bool.TryParse(Console.ReadLine(), out isClub);
            Console.WriteLine("מועד תחילת המבצע:");
            DateTime startSale;
            DateTime.TryParse(Console.ReadLine(), out startSale);
            Console.WriteLine("מועד סיום המבצע:");
            DateTime endSale;
            DateTime.TryParse(Console.ReadLine(), out endSale);
            return new Sale(0, id, quantityForSale, salePrice, isClub, startSale, endSale);
        }

        private static Customer CreateCustomer()
        {
            Console.WriteLine("אנא הכנס את הנתונים הבאים:");
            //get all props from user and create(item)
            Console.WriteLine("הכנס את מספר תעודת הזהות של הלקוח");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("הכנס את שם הלקוח");
            string name = Console.ReadLine();
            Console.WriteLine("הכנס את כתובת הלקוח");
            string address = Console.ReadLine();
            Console.WriteLine("הכנס את מספר הטלפון של הלקוח");
            string phonNumber = Console.ReadLine();
            return new Customer(id, name, address, phonNumber);
        }


        private static Product CreateProduct()
        {
            Console.WriteLine("אנא הכנס את הנתונים הבאים:");
            Console.WriteLine("שם המוצר:");
            String ProductName = Console.ReadLine();
            Console.WriteLine(":קטגוריה ");
            Categories Category;
            Categories.TryParse(Console.ReadLine(), out Category);
            Console.WriteLine(":מחיר ");
            int Price;
            int.TryParse(Console.ReadLine(), out Price);
            Console.WriteLine("כמות במלאי: ");
            int AmountInStock;
            int.TryParse(Console.ReadLine(), out AmountInStock);
            return new Product(0, ProductName, Category, Price, AmountInStock);
        }

        private static void ReadAll<T>(ICrud<T> currentReferance)
        {
            try
            {
                Console.WriteLine(string.Join("\n", currentReferance.ReadAll()));
            }
            catch (Exception e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                Console.WriteLine(e.Message);
            }
        }

        private static void Delete<T>(ICrud<T> currentReferance)
        {
            try
            {
                Console.WriteLine("insert an id:");
                int id = int.Parse(Console.ReadLine());
                currentReferance.Delete(id);
            }
            catch (Exception e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                Console.WriteLine(e.Message);
            }
        }

        private static void Update<T>(ICrud<T> currentReferance)
        {
            if (currentReferance != null)
            {
                if (currentReferance is IProduct)
                {
                    try
                    {
                        s_dal.Product.Update(CreateProduct());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
                if (currentReferance is ICustomer)
                {

                    try
                    {
                        s_dal.Customer.Update(CreateCustomer());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
                if (currentReferance is ISale)
                {
                    try
                    {
                        s_dal.Sale.Update(CreateSale());
                    }
                    catch (Exception e)
                    {
                        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                        Console.WriteLine(e.ToString());
                    }
                }
            }

        }

        private static void Read<T>(ICrud<T> currentReferance)
        {
            try
            {
                Console.WriteLine("insert an id to read");
                int id = int.Parse(Console.ReadLine());
                if (int.TryParse(Console.ReadLine(), out id))
                Console.WriteLine(currentReferance.Read(id));
            }
            catch (Exception e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName.ToString(), MethodBase.GetCurrentMethod().Name, e.Message);
                Console.WriteLine(e.Message);
            }
        }

        private static void MainMenu()
        {
            int type;
            do
            {
                Console.WriteLine("למוצר הקש 1\nללקוח הקש 2 \n למבצע הקש 3 \n ליציאה הקש 0");
                int.TryParse(Console.ReadLine(), out type);
                switch (type)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            try
                            {
                                crudMenu("Product", s_dal.Product);
                            }
                            catch
                            {
                                throw;
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {

                                crudMenu("Customer", s_dal.Customer);

                            }
                            catch
                            {
                                throw;
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                crudMenu("Sale", s_dal.Sale);
                            }
                            catch
                            {
                                throw;
                            }
                            break;
                        }
                    default: return;

                }
            } while (type != 0);

        }


    }
}