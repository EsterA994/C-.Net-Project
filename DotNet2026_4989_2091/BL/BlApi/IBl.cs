using BlApi;

namespace BL.BlApi;

internal class IBl
{
    IProduct Product { get; }
    ISale Sale { get; }
    ICustomer Customer { get; }
    IOrder Order { get; }
}
