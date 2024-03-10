namespace DojoCat.Members.Common.Errors;

public record Error
{
    public static Error Success =>
        new("Success", "Request completed successfully", ErrorType.None);

    private Error(string code, string description, ErrorType errorTypeype)
    {
        Code = code;
        Description = description;
        ErrorType = errorTypeype;
    }

    public string Code { get; }
    public string Description { get; }
    public ErrorType ErrorType { get; }

    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);
        
    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);
    
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);
    
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);
}

public enum ErrorType
{
    None = -1,
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3
}