/// <summary>
/// Request payload to update an encounter.
/// </summary>
public record UpdateEncounterDto
{
    /// <summary>
    /// Encounter identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Optional updated encounter name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Optional updated current round.
    /// </summary>
    public int? CurrentRound { get; set; }

    /// <summary>
    /// Optional active monster identifier.
    /// </summary>
    public int? ActiveMonsterId { get; set; }
}