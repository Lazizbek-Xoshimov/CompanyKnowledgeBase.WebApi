namespace Models.Exceptions;

public class NotFoundException : Exception
{
    public string Message { get; set; }
    public string Description { get; set; }
    
    public NotFoundException(string message, string decription) : base(message)
    {
        this.Message = message;
        this.Description = decription;
    }
}