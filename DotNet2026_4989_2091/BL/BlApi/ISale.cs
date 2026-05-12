using BO;

namespace BlApi;

public interface ISale
{

    public int Create(Sale item);
    public Sale? Read(Func<Sale, bool> filter);
    public Sale? Read(int id);
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null);
    public void Delete(int id);
    public void Update(Sale item);
}
