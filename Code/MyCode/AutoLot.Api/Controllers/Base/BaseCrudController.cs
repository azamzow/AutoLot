﻿namespace AutoLot.Api.Controllers.Base;

[ApiVersion(1.0)]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseCrudController<TEntity, TController>(IAppLogging<TController> logger, IBaseRepo<TEntity> repo) : ControllerBase where TEntity : BaseEntity, new() where TController : class
{
    protected readonly IBaseRepo<TEntity> MainRepo = repo;
    protected readonly IAppLogging<TController> Logger = logger;

    /// <summary>
    /// Gets all records
    /// </summary>
    /// <returns>All records</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpGet]
    public ActionResult<IEnumerable<TEntity>> GetAll()
    {
        return Ok(MainRepo.GetAllIgnoreQueryFilters());
    }

    /// <summary>
    /// Gets a single record
    /// </summary>
    /// <param name="id">Primary key of the record</param>
    /// <returns>Single record</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(204, "No content")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpGet("{id}")]
    public ActionResult<TEntity> GetOne(int id)
    {
        var entity = MainRepo.Find(id);
        if (entity == null)
        {
            return NoContent();
        }
        return Ok(entity);
    }

    /// <summary>
    /// Updates a single record
    /// </summary>
    /// <remarks>
    /// Sample body:
    /// <pre>
    /// {
    /// "Id": 1,
    /// "TimeStamp": "AAAAAAAAB+E="
    /// "MakeId": 1,
    /// "Color": "Black",
    /// "PetName": "Zippy",
    /// "MakeColor": "VW (Black)",
    /// }
    /// </pre>
    /// </remarks>
    /// <param name="id">Primary key of the record to update</param>
    /// <param name="entity">Entity to update</param>
    /// <returns>Single record</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpPut("{id}")]
    public IActionResult UpdateOne(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        try
        {
            MainRepo.Update(entity);
        }
        catch (CustomException ex)
        {
            //This shows an example with the custom exception
            //Should handle more gracefully
            return BadRequest(ex);
        }
        catch (Exception ex)
        {
            //Should handle more gracefully
            return BadRequest(ex);
        }
        return Ok(entity);
    }

    /// <summary>
    /// Adds a single record
    /// </summary>
    /// <remarks>
    /// Sample body:
    /// <pre>
    /// {
    /// "Id": 1,
    /// "TimeStamp": "AAAAAAAAB+E="
    /// "MakeId": 1,
    /// "Color": "Black",
    /// "PetName": "Zippy",
    /// "MakeColor": "VW (Black)",
    /// }
    /// </pre>
    /// </remarks>
    /// <returns>Added record</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpPost]
    public ActionResult<TEntity> AddOne(TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        try
        {
            MainRepo.Add(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Deletes a single record
    /// </summary>
    /// <remarks>
    /// Sample body:
    /// <pre>
    /// {
    /// "Id": 1,
    /// "TimeStamp": "AAAAAAAAB+E="
    /// }
    /// </pre>
    /// </remarks>
    /// <returns>Nothing</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpDelete("{id}")]
    public ActionResult<TEntity> DeleteOne(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }
        try
        {
            MainRepo.Delete(entity);
        }
        catch (Exception ex)
        {
            //Should handle more gracefully
            return new BadRequestObjectResult(ex.GetBaseException()?.Message);
        }
        return Ok();
    }
}