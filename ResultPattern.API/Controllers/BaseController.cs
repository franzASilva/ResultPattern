using Microsoft.AspNetCore.Mvc;
using ResultPattern.API.Controllers.Constants;
using ResultPattern.API.Controllers.Responses;

namespace ResultPattern.API.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult ApiBadRequest(ApiErrorType type, string businessError, string? exceptionMessage)
    {
        return StatusCode(StatusCodes.Status400BadRequest, new ApiBadRequestResponse
        {
            Type = type.ToString(),
            Error = businessError,
            Detail = exceptionMessage ?? string.Empty
        });
    }
}
