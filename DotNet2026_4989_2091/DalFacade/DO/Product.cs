namespace DO;

public record Product(
    int ProdId,
    string ProdName,
    ProdCategory ProdCategory,
    double Price,
    int QuantityInStock
    )
{
    public Product() : this(0, "", ProdCategory.קופסא, 0, 0) { }
}
