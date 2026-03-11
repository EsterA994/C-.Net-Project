namespace DalApi;

public interface ICrud<T>
{
    public int Create(T item);
    public T? Read(int id);
    public List<T> ReadAll(Func<T,bool>? filter =null);
    public void Delete(int id);
    public void Update(T item);
}

