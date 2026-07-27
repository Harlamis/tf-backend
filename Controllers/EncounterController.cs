using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateEncounterDto dto)
    {
        // return Ok(await _service.CreateEncounterAsync(dto));
        var newId = await _service.CreateEncounterAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
    }

    [HttpPatch]
    public async Task<ActionResult> Update(UpdateEncounterDto dto)
    {
        bool isUpdated = await _service.UpdateEncounterAsync(dto);
        return isUpdated ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteEncounterAsync(id);
        return Ok();
    }
}