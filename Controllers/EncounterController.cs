using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trackfinder.Api.Controllers;

/// <summary>
/// Provides encounter operations and monster management.
/// </summary>
[ApiController]
[Route("api/v1/encounters")]
[Produces("application/json")]
public class EncounterController : ControllerBase
{
    private readonly IEncounterService _service;

    public EncounterController(IEncounterService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all encounters.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EncounterDto>))]
    public async Task<ActionResult<List<EncounterDto>>> GetAll()
    {
        var encounters = await _service.GetAllEncountersAsync();

        return Ok(encounters);
    }

    /// <summary>
    /// Retrieves an encounter by its identifier.
    /// </summary>
    /// <param name="id">Encounter identifier.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EncounterDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EncounterDto>> GetById(int id)
    {
        var encounter = await _service.GetEncounterByIdAsync(id);

        if (encounter == null) return NotFound();

        return Ok(encounter);
    }

    /// <summary>
    /// Creates a new encounter.
    /// </summary>
    /// <param name="dto">Encounter creation payload.</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create([FromBody] CreateEncounterDto dto)
    {
        var newId = await _service.CreateEncounterAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
    }

    /// <summary>
    /// Updates an existing encounter.
    /// </summary>
    /// <param name="dto">Encounter update payload.</param>
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateEncounterDto dto)
    {
        bool isUpdated = await _service.UpdateEncounterAsync(dto);
        return isUpdated ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes an encounter by ID.
    /// </summary>
    /// <param name="id">Encounter identifier.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.DeleteEncounterAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Adds a monster to an encounter.
    /// </summary>
    /// <param name="dto">Monster addition payload.</param>
    [HttpPost("monsters")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActiveMonsterDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ActiveMonsterDto>> AddMonster([FromBody] AddMonsterToEncounterDto dto)
    {
        var newMonster = await _service.AddMonsterToEncounterAsync(dto);

        if (newMonster == null) return NotFound($"Could not find template with TemplateId: {dto.TemplateId}");

        return Ok(newMonster);
    }

    /// <summary>
    /// Updates an encounter monster.
    /// </summary>
    /// <param name="dto">Monster update payload.</param>
    [HttpPatch("monsters")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateMonster([FromBody] UpdateMonsterDto dto)
    {
        bool isUpdated = await _service.UpdateMonsterAsync(dto);
        return isUpdated ? NoContent() : NotFound();
    }

    /// <summary>
    /// Deletes a monster from an encounter.
    /// </summary>
    /// <param name="id">Monster identifier.</param>
    [HttpDelete("monsters/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteMonster(int id)
    {
        await _service.DeleteMonsterAsync(id);
        return Ok();
    }
}