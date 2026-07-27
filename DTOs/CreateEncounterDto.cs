/// <summary>
/// Request payload to create a new encounter.
/// </summary>
public record CreateEncounterDto
{
    /// <summary>
    /// The name of the encounter.
    /// </summary>
    public string Name { get; set; } = null!;
}