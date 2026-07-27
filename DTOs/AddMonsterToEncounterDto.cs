/// <summary>
/// Request payload for adding a monster to an encounter.
/// </summary>
public record AddMonsterToEncounterDto
{
    /// <summary>
    /// The template identifier of the monster to add.
    /// </summary>
    public string TemplateId { get; set; } = null!;

    /// <summary>
    /// The identifier of the encounter to update.
    /// </summary>
    public int EncounterId { get; set; }
}