using DO;
using DalApi;

namespace Dal;

public static class Initialization
{
    private static IDal? s_dal;

    private static void CreateSale()
    {
        s_dal.Sale.Create(new Sale(0,150,150,550,false,new DateTime(2024,01,09), new DateTime(2024 , 10 , 20)));
        s_dal.Sale.Create(new Sale(0, 152, 150, 310, false, new DateTime(2021 , 09 , 24), new DateTime(2021 , 10 , 24)));     
        s_dal.Sale.Create(new Sale(0,150,150,550,false,new DateTime(2022,09,29), new DateTime(2023 , 1 , 5)));
        s_dal.Sale.Create(new Sale(0, 152, 150, 310, false, new DateTime(2024 , 09 , 21), new DateTime(2025 , 10 , 21)));

    }
    private static void CreateProduct()
    {
        s_dal.Product.Create(new Product(0, "סט מחזורים עור אמיתי סדר תפילותינו אשכנז", Categories.מחזורים, 580, 150));
        s_dal.Product.Create(new Product(0, "סט מחזורים לימים נוראים סדר תפילותינו אשכנז", Categories.מחזורים, 65, 350));
        s_dal.Product.Create(new Product(0, "סט מחזורים עור אמיתי עת רצון אשכנז", Categories.מחזורים, 320, 150));
        s_dal.Product.Create(new Product(0, "סט מחזורים עור אמיתי סדר תפילותינו ספרד", Categories.מחזורים,580,100));
        s_dal.Product.Create(new Product(0, "סט מחזורים לימים נוראים סדר תפילותינו ספרד", Categories.מחזורים, 65, 250));
        s_dal.Product.Create(new Product(0, "סט מחזורים עור אמיתי עת רצון ספרד", Categories.מחזורים, 320, 100));
        s_dal.Product.Create(new Product(0, ".סט מחזורים עור אמיתי עת רצון ע.מ", Categories.מחזורים, 320, 100));


    }

    private static void CreateCustomer()
    {
        
        s_dal.Customer.Create(new Customer(327777777,"יהושע כהן","רבי עקיבא 12","0546809876"));
        s_dal.Customer.Create(new Customer(327820445, "משה כהנא", "רבי טרפון 3", "0548509555"));
        s_dal.Customer.Create(new Customer(329745727, "Michael Davidson", "Rashbi 42", "0546833222"));
        s_dal.Customer.Create(new Customer(329905727, "Menashe Reuven", "Netivot Hamishpat 101", "0533835892"));
        s_dal.Customer.Create(new Customer(340745727, "Yizchak Lurya", "Netivot Shalom 12", "0732348568"));
        s_dal.Customer.Create(new Customer(317907777, "Nechama Davidovitz", "Saarey Teshuva  12", "0527601988"));
        s_dal.Customer.Create(new Customer(327777997, "Menashe Reuven", "Rabi Natan 1", "0548465889"));
        s_dal.Customer.Create(new Customer(327723477, "Moshe Cohen", "Rabi Tarfon 3", "0548566670"));
        s_dal.Customer.Create(new Customer(327839445, "Aharon Kagan", "Netivot Hamishpat 54", "0546799876"));
    }


    public static void intialize()
    {
        s_dal = Factory.Get;
        CreateCustomer();
        CreateProduct();
        CreateSale();
    }
}
