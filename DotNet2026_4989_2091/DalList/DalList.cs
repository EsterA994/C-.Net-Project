using DalApi;

namespace Dal;
<<<<<<< HEAD
sealed internal class DalList : IDal
=======
public class DalList : IDal
>>>>>>> main
{
    private  readonly DalList instance=new DalList();

    private DalList()
    {

    }
    public static int Instance
    {
       // get { return this.instance; }
    }

  
   
    public IProduct Product => new ProductImplemention();

    public ISale Sale => new SaleImplamention();

    public ICustomer Customer => new CustomerImplemention();
}

