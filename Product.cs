using DO;

namespace BO
{
    /// <summary>
    /// ���� ���� ������ �� ������� �����:
    /// ���� ���� ������
    /// �� �����
    /// �������
    /// ����
    /// ���� �����
    /// </summary>
    public class Product
    {
        public int Code { get; set; }
        public string? ProductName { get; set; }
        public Categories? Category { get; set; }
        public double? Price { get; set; }
        public int? AmountInStock { get; set; }
        public List<SaleInProduct> SaleInProductList { get; set; }
        public override string ToString() => this.ToStringProperty();

        public Product(int code, string? productName, Categories? category, double? price, int? amountInStock, List<SaleInProduct> saleInProductList)
        {
            Code = code;
            ProductName = productName;
            Category = category;
            Price = price;
            AmountInStock = amountInStock;
            SaleInProductList = saleInProductList;
        }

        public Product()
        {
        }
    }
}
