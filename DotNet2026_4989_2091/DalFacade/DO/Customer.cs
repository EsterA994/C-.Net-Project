namespace DO;

public record Customer(
    int CustId,
    string CustName,
    string CustAddress,
    string CustPhone
    )
{
    public Customer() : this(0, "", "", "") { }
}