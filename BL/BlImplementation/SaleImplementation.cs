using BlApi;

namespace BlImplementation;

internal class SaleImplementation:BlApi.ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Sale item)
    {
        try
        {
            return _dal.Sale.Create(BO.Tools.Convert(item));
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
            _dal.Sale.Delete(code);
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
            DO.Sale? s = _dal.Sale.Read(sale => sale.SaleCode == code);
            return (!(s == null));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public BO.Sale? Read(int code)
    {
        try
        {
            return BO.Tools.Convert(_dal.Sale.Read(code));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public BO.Sale? Read(Func<BO.Sale, bool>? filter)
    {
        try
        {
            return BO.Tools.Convert(_dal.Sale.Read(s => filter(BO.Tools.Convert(s!))));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        try
        {
            return _dal.Sale.ReadAll(s => filter!(BO.Tools.Convert(s!))).Select(s => BO.Tools.Convert(s!)).ToList()!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public void Update(BO.Sale item)
    {
        try
        {
            _dal.Sale.Update(BO.Tools.Convert(item));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
