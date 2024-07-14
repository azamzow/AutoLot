// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersionNeutral]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController(IAppLogging<ValuesController> logger) : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    public IActionResult TestLogging()
    {
        //logger.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    public IActionResult TestExceptionHandling()
    {
        throw new Exception("Test Exception");
    }
}
