using BlApi;
using BO;
using DO;


namespace BlImplementation;

internal class OrderImplementation : BlApi.IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public List<SaleInProduct> AddProductToOrder(Order order, int code, int amount)
    {
        try
        {
            BO.Product product = BO.Tools.Convert(_dal.Product.Read(code));
            BO.ProductInOrder? prod=order.ProductInOrderList.FirstOrDefault(p=>p.ProductId==code);
            if (prod != null)
            {
                //product to add does not exist
                if (product.AmountInStock < amount)
                    throw new Exception("Not enough amount in stock");
                BO.ProductInOrder newProduct = new ProductInOrder(code, product.ProductName, (double)product.Price, amount, null, 0);
                newProduct.SaleInThisProductList=SearchSalesForProduct(newProduct, order.IsInClub);
                order.ProductInOrderList.Add(newProduct);
                prod = newProduct;

            }
            else
            {
                //product to add exists already
                if (product.AmountInStock < amount)
                    throw new Exception("Not enough amount in stock");


            }
            //calculate price
            CalcTotalPriceForProduct(prod,order.IsInClub);
            CalcTotalPrice(order);
            return prod.SaleInThisProductList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<SaleInProduct> AddProductToOrder(Order order, int code)
    {
        throw new NotImplementedException();
    }

    public void CalcTotalPrice(Order order)
    {
        try
        {
            order.TotalPrice = (from p in order.ProductInOrderList
                                select p.ProductTotalPrice).Sum();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public void CalcTotalPriceForProduct(ProductInOrder productInOrder, bool IsInClub)
    {
        try
        {
            SearchSalesForProduct(productInOrder, IsInClub);
            if (productInOrder.SaleInThisProductList!.Count() == 0)
            {
                productInOrder.ProductTotalPrice = productInOrder.ProductBasePrice * productInOrder.AmountInOrder;
            }
            else
            {
                productInOrder.ProductTotalPrice = 0;

                int? count = productInOrder.AmountInOrder;
                List<BO.SaleInProduct> activeSales = new List<BO.SaleInProduct>();

                // מיון המבצעים לפי מחיר ליחידה הכי משתלם
                var sortedSales = productInOrder.SaleInThisProductList
                    .Where(s => s != null && s.AmountForSale > 0)
                    .OrderBy(s => (double)s.SalePrice / s.AmountForSale)
                    .ToList();

                foreach (var sale in sortedSales)
                {
                    if (count <= 0)
                        break;

                    int applicableTimes = (int)(count / sale.AmountForSale);
                    if (applicableTimes > 0)
                    {
                        productInOrder.ProductTotalPrice += applicableTimes * sale.AmountForSale;
                        count -= applicableTimes * sale.AmountForSale;
                        activeSales.Add(sale);
                    }
                }

                // אם נשארו יחידות שלא כיסינו על ידי המבצעים
                if (count > 0)
                    productInOrder.ProductTotalPrice += (double)(count * productInOrder.ProductBasePrice);

                // שמירת רק המבצעים שיושמו
                productInOrder.SaleInThisProductList = activeSales;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DoOrder(Order order)
    {
        try
        {
            foreach (var productInOrder in order.ProductInOrderList)
            {
                DO.Product productDO = _dal.Product.Read(productInOrder.ProductId);
                if (productDO == null)
                {
                    throw new Exception("שגיאה בתשלום הזמנה");
                }
                _dal.Product.Update(productDO with { AmountInStock = productDO.AmountInStock - productInOrder.AmountInOrder });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    public List<SaleInProduct> SearchSalesForProduct(ProductInOrder productInOrder, bool isInClub)
    {
        try
        {
            List<DO.Sale?> sales = _dal.Sale.ReadAll();
            sales = (from s in sales
                     where s.SaleCode == productInOrder.ProductId &&
                           s.SaleBeginningDate <= DateTime.Now &&
                           s.SaleEndDate > DateTime.Now &&
                           (isInClub || !(bool)s.IsForClub) &&
                           productInOrder.AmountInOrder >= s.AmountForSale
                     select s).ToList();
            if (!isInClub)
            {
                sales = sales.FindAll(s => !(bool)s.IsForClub);
            }
            List<BO.SaleInProduct> listSaleInProductBO = (from s in sales
                                                          select new BO.SaleInProduct(s.SaleCode, (int)s.AmountForSale, (int)s.TotalSalePrice, (bool)s.IsForClub)).ToList();
            return listSaleInProductBO.OrderBy(p => p.SalePrice / p.AmountForSale).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
