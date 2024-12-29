using FluentValidation.Results;

namespace ShopYenSao.Application.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string name, object key) : base($"{name} with ID {key} was not found")
    {
        
    }
}

public class BadRequestException : System.Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }
    public BadRequestException(string message,ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
    
    public IDictionary<string, string[]> ValidationErrors { get; set; }

}