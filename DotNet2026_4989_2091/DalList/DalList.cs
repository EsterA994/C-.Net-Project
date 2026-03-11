using DalApi;

namespace Dal;
sealed internal class DalList : IDal
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

