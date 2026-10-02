namespace Models.Exceptions;

public class ValidationException : Exception
{
    public string Message { get; set; }
    public string Description { get; set; }
    
    public ValidationException(string message, string decription) : base(message)
    {
        this.Message = message;
        this.Description = decription;
    }
}