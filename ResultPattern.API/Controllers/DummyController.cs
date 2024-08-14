using Microsoft.AspNetCore.Mvc;
using ResultPattern.API.Controllers.Constants;
using ResultPattern.API.Controllers.Responses;
using ResultPattern.Domain.Model;
using ResultPattern.Domain.Services.Interfaces;

namespace ResultPattern.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController() : BaseController
{
    /// <summary>
    /// Get all summies values
    /// </summary>
    /// <param name="dummyService"></param>
    /// <returns>List of dummies</returns>
    /// <response code="200">Returns a list of dummies</response>
    /// <response code="404">If the item is null or zero</response>
    [HttpGet(Name = "GetDummiesValues")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<Dummy>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Get(IDummyService dummyService)
    {
        var ret = dummyService.GetDummiesValues();

        if (ret.Success)
        {
            return Ok(ret.ReturnValue);
        }

        return NotFound(ret.BusinessError);
    }

    /// <summary>
    /// Save a dummy
    /// </summary>
    /// <param name="dummyService"></param>
    /// <param name="dummy"></param>
    /// <returns>Saved dummy</returns>
    /// <response code="200">Dummy was saved</response>
    /// <response code="400">Dummy wasn't saved</response>
    [HttpPost(Name = "PostNewDummy")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DummyModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiBadRequestResponse), StatusCodes.Status400BadRequest)]
    public IActionResult Post(IDummyService dummyService, DummyModel dummy)
    {
        var ret = dummyService.SaveDummy(dummy);

        if (ret.Success)
        {
            return Ok(ret.ReturnValue);
        }

        return ApiBadRequest(ApiErrorType.BusinessError, ret.BusinessError, ret.Error?.Message);
    }
}
