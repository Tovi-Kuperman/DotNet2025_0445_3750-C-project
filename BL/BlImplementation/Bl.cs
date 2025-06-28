
using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    public ISale Sale => new SaleImplementation();

    public IProduct Product => new ProductImplementation();

    public ICustomer Customer => new CustomerImplementation();

    public IOrder Order => new OrderImplementation();

    public Bl() { }
}