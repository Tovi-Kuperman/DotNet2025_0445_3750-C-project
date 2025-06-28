using BlApi;

namespace BlImplementation;

internal class CustomerImplementation:BlApi.ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Customer item)
    {
        try
        {
            return _dal.Customer.Create(BO.Tools.Convert(item));
        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
        }

    }

    public void Delete(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool isExists(int id)
    {
        try
        {
            DO.Customer? c = _dal.Customer.Read(cust => cust.Id == id);
            return (!(c == null));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public BO.Customer? Read(int id)
    {
        try
        {
            return BO.Tools.Convert(_dal.Customer.Read(id));
        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
        }
    }

    public BO.Customer? Read(Func<BO.Customer, bool>? filter)
    {
        try
        {
            return BO.Tools.Convert(_dal.Customer.Read(c => filter(BO.Tools.Convert(c!))));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        try
        {
            return _dal.Customer.ReadAll(c => filter!(BO.Tools.Convert(c!))).Select(c => BO.Tools.Convert(c!)).ToList()!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

   

    public void Update(BO.Customer item)
    {
        try
        {
            _dal.Customer.Update(BO.Tools.Convert(item));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
