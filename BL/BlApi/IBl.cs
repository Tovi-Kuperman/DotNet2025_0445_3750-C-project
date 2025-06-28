

using BlApi;

namespace BlApi
{
    public interface IBl
    {

        public IProduct Product { get; }
        public ISale Sale { get; }
        public ICustomer Customer { get; }
        public IOrder Order { get; }

    }
}
