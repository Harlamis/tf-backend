using Microsoft.AspNetCore.Mvc;

namespace Trackfinder.Api.Controllers;

/// <summary>
/// Provides access to Templates repository a.k.a Bestiary
/// </summary>
[ApiController]
[Route("api/v1/templates")]
[Produces("application/json")]
public class MonsterTemplateController : ControllerBase
{
    private readonly IMonsterTemplateService _service;

    public MonsterTemplateController(IMonsterTemplateService service)
    {
        _service = service;
    }

    /// <summary>
    /// Returns all Templates
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MonsterTemplateDto>))]
    public async Task<ActionResult<List<MonsterTemplateDto>>> GetAll()
    {
        return Ok(await _service.GetAllTemplatesAsync());
    }
}