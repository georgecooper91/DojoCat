using DojoCat.Members.Common.Errors;

namespace DojoCat.Members.Domain.Exceptions;

public static class GeneralErrors
{
    public static Error InternalError => 
        Error.Failure("Internal.Error", "The system encountered a problem, please try again");

    public static Error PartialSuccess(string description) => 
        Error.PartialSuccess("Success.Partial", description);
}
