
namespace BO;

public class Customer
{
    /// <summary>
    /// ישות לקוח המכילה את התכונות הבאות:
    /// תעודת זהות
    /// שם הלקוח
    /// כתובת
    /// טלפון
    /// </summary>
    public  int Id {get; set;}
    public  string? Name {get; set;}
    public  string? Address {get; set;}
    public  string PhoneNumber { get; set; }
    public override string ToString() => this.ToStringProperty();

    public Customer(int id, string? name, string? address, string phoneNumber)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }


}
