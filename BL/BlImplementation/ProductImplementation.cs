using BlApi;
using BO;


namespace BlImplementation;

internal class ProductImplementation : BlApi.IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item)
    {
        try
        {
            return _dal.Product.Create(BO.Tools.Convert(item));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public void Delete(int code)
    {
        try
        {
            _dal.Product.Delete(code);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool isExists(int code)
    {
        try
        {
            DO.Product? p = _dal.Product.Read(prod => prod.Code == code);
            return (!(p == null));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public BO.Product? Read(int code)
    {
        try
        {
            return BO.Tools.Convert(_dal.Product.Read(code));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public BO.Product? Read(Func<BO.Product, bool>? filter)
    {
        try
        {
            return BO.Tools.Convert(_dal.Product.Read(p => filter(BO.Tools.Convert(p!))));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        try
        {
            // Fixing CS1026 and CS0023 by correcting parentheses and lambda expression usage
            return _dal.Product.ReadAll(p => filter == null || filter(BO.Tools.Convert(p!)))
                                .Select(p => BO.Tools.Convert(p!))
                                .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<SaleInProduct> GetActiveSales(int code, bool isInClub, int amount)
    {
        try
        {
            List<DO.Sale?> sales = _dal.Sale.ReadAll();
            sales = (from s in sales
                     where s.SaleCode == code
                     select s).ToList();
            if (!isInClub)
            {
                sales = sales.FindAll(s => !(bool)s.IsForClub);
            }
            List<BO.SaleInProduct> listSaleInProductBO = (from s in sales
                                                          where s.SaleBeginningDate <= DateTime.Now && s.SaleEndDate > DateTime.Now && amount >= s.AmountForSale
                                                          select new BO.SaleInProduct(s.SaleCode, (int)s.AmountForSale, (double)s.TotalSalePrice, (bool)s.IsForClub)).ToList();
            return listSaleInProductBO.OrderBy(p => p.SalePrice / p.AmountForSale).ToList();


        }
         catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(BO.Product item)
    {
        try
        {
            _dal.Product.Update(BO.Tools.Convert(item));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
