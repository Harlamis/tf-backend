using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/encounters")]
public class EncounterController : ControllerBase
{
    private readonly IEncounterService _service;

    public EncounterController(IEncounterService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<EncounterDto>>> GetAll()
    {
        var encounters = await _service.GetAllEncountersAsync();

        return Ok(encounters);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<EncounterDto>> GetById(int id)
    {
        var encounter = await _service.GetEncounterByIdAsync(id);

        if (encounter == null) return NotFound();

        return Ok(encounter);
    }
}