using System.Diagnostics;
using DalApi;

namespace Dal;

internal class DalXml : IDal
{

    private static readonly DalXml instance = new DalXml();
    public static DalXml Instance { get { return instance; } }

    private DalXml()
    {
    }
    public IProduct Product => new ProductImplementation();

    public ISale Sale => new SaleImplementation();

    public ICustomer Customer
    {
        get
        {
            return new CustomerImplementation();
        }
    }
}
