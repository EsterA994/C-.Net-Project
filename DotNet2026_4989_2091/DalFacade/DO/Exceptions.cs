namespace DO;

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

/// <summary>
/// /
/// </summary>
[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
}