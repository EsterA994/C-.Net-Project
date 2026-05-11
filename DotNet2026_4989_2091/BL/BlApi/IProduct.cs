using BO;

namespace BlApi;
public interface IProduct
{    public int Create(Product item);
    public Product? Read(Func<Product, bool> filter);
    public Product? Read(int id);
    public List<Product> ReadAll(Func<Product, bool>? filter = null);
    public void Delete(int id);
    public void Update(Product item);
    public void GetSales(ProductInOrder productInOrder, bool isClubMember);
}
