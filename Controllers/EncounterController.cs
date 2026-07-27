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
    public async Task<ActionResult<EncounterDto>> GetAll()
    {
        var encounters = await _service.GetAllEncountersAsync();

        return Ok(encounters);
    }
}