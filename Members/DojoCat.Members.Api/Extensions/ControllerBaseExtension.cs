using DojoCat.Members.Common.Errors;
using DojoCat.Members.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace DojoCat.Members.Api.Extensions;

public static class ControllerBaseExtension
{
    public static ObjectResult ReturnError(this ControllerBase cb, Result result)
    {    
        return cb.Problem
        (
            statusCode: GetStatusCode(result.Error.ErrorType),
            detail: result.Error.Description,
            title: result.Error.Code,
            type: GetTitle(result.Error.ErrorType)
        );
    }

    private static string GetTitle(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => "Bad Request",
            ErrorType.NotFound => "Not Found",
            ErrorType.Conflict => "Conflict",
            ErrorType.PartialSuccess => "Partial Success",
            _ => "Internal Server Error"
        };

    private static int GetStatusCode(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.PartialSuccess => StatusCodes.Status207MultiStatus,
            _ => StatusCodes.Status500InternalServerError
        };
}
