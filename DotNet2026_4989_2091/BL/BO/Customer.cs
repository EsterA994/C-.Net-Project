namespace BO;

public class Customer
{
    public int CustId { get; set; }
    public string CustName { get; set; }
    public string CustAddress { get; set; }
    public string CustPhone { get; set; }

    public override string ToString() => this.ToStringProperty();
}
