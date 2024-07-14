// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarsController(IAppLogging<CarsController> logger, ICarRepo repo)
    : BaseCrudController<Car, CarsController>(logger, repo)
{
    /// <summary>
    /// Gets all cars by make
    /// </summary>
    /// <returns>All cars for a make</returns>
    /// <param name="id">Primary key of the make</param>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")] 
    [HttpGet("bymake/{id?}")]
    public ActionResult<IEnumerable<Car>> GetCarsByMake(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            return Ok(((ICarRepo)MainRepo).GetAllBy(id.Value));
        }
        return Ok(MainRepo.GetAllIgnoreQueryFilters());
    }

        /// <summary>
    /// Gets all records
    /// </summary>
    /// <returns>All records</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [ApiVersion("0.5", Deprecated = true)]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllBad()
    {
        throw new Exception("I said not to use this one");
    }

    /// <summary>
    /// Gets all records really fast (when it’s written)
    /// </summary>
    /// <returns>All records</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [ApiVersion("2.0-Beta")]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllFuture()
    {
        throw new NotImplementedException("I'm working on it");
    }
}