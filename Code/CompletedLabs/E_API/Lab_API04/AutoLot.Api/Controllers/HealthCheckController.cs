using System.Net;

namespace AutoLot.Api.Controllers;

[ApiVersionNeutral]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class HealthCheckController : Controller
{
    [HttpOptions]
    public IActionResult Options([FromServices] ApiVersion apiVersion)
    {
        //Can also get the version information from the HTTPContext
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var response = new HttpResponseMessage
        {
            Content = new StringContent(string.Empty),
            StatusCode = HttpStatusCode.OK,
            Version = new Version(version?.MajorVersion ?? 0, version?.MinorVersion ?? 0)
        };
        response.Content.Headers.Add("Allow", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });
        response.Content.Headers.ContentType = null;
        return Ok(response);
    }
}