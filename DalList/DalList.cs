using DalApi;

namespace Dal
{
    sealed internal
        class DalList:IDal
    {
        public IProduct Product => new ProductImplementation();
        public ICustomer Customer => new CustomerImplementation();
        public ISale Sale => new SaleImplementation();

        private static readonly DalList instance = new DalList() ;
        public static DalList Instance { get { return instance ; } }

        private DalList()
        {

        }

    }
}
