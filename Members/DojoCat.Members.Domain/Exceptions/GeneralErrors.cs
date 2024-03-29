﻿using DojoCat.Members.Common.Errors;

namespace DojoCat.Members.Domain.Exceptions;

public static class GeneralErrors
{
    public static Error InternalError => 
        Error.Failure("Internal.Error", "There system encountered a problem, please try again");
}
