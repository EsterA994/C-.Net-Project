namespace Dal;

[Serializable]
public class DalIdNotFoundExceptions: Exception
{
    public DalIdNotFoundExceptions(string message):base(message) { }
}
[Serializable]
public class DalIdAlreadyExistExceptions : Exception
{
    public DalIdAlreadyExistExceptions(string message) : base(message) { }
}
