using DojoCat.Members.Common.Errors;

namespace DojoCat.Members.Domain.Errors;

public static class UserErrors
{
    public static Error UsernameAlreadyInUse => Error.Conflict("Error.Username", "Username already in use");

    public static Error IncorrectUsernamePassword => 
        Error.Validation("User.Login", "Password or username is incorrect");

    public static Error UserNotFound => 
        Error.NotFound("User.NotFound", "Could not find the user in question");

    public static Error EmergencyContact => 
        Error.Conflict("User.EmergencyContact", "Emergency contact number can not be the same as member number");
}
