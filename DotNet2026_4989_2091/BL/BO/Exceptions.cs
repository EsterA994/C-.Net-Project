namespace BO;
[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
    public BlDoesNotExistException(string message, Exception innerException)
                : base(message, innerException) { }
 
}
[Serializable]
public class BlIdAlreadyExistExceptions : Exception
{
    public BlIdAlreadyExistExceptions(string? message) : base(message) { }
    public BlIdAlreadyExistExceptions(string message, Exception innerException)
                : base(message, innerException) { }

}
[Serializable]
public class BlInvalidInputException : Exception
{ 
    public BlInvalidInputException(string? message) : base(message) { }
    public BlInvalidInputException(string message, Exception innerException)
                : base(message, innerException) { }
}
[Serializable]
public class BlDeletionImpossibleException : Exception
{
    public BlDeletionImpossibleException(string? message) : base(message) { }
    public BlDeletionImpossibleException(string message, Exception innerException)
                : base(message, innerException) { }
}

[Serializable]
public class BlOutOfStock : Exception
{
    public BlOutOfStock(string? message) : base(message) { }
    public BlOutOfStock(string message, Exception innerException)
                : base(message, innerException) { }
}