/// <summary>
/// Represents an encounter and its active monsters.
/// </summary>
public record EncounterDto
{
    /// <summary>
    /// Encounter identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Current round in the encounter.
    /// </summary>
    public int CurrentRound { get; set; }

    /// <summary>
    /// Optional active monster identifier.
    /// </summary>
    public int? ActiveMonsterId { get; set; }

    /// <summary>
    /// Name of the encounter.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Monsters participating in the encounter.
    /// </summary>
    public List<ActiveMonsterDto> Monsters { get; set; } = new();
}