
using BO;
namespace BlApi;

public interface ISale
{
    int Create(Sale item); //Creates new entity object in DAL
    Sale? Read(int id); //Reads entity object by its ID 
    Sale? Read(Func<Sale, bool>? filter);// Reads entity object by some parameter
    List<Sale?> ReadAll(Func<Sale, bool>? filter = null); //stage 1 only, Reads all entity objects
    void Update(Sale item); //Updates entity object
    void Delete(int id); //Deletes an object by its Id
}
