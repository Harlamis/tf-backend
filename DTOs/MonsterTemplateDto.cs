/// <summary>
/// Represents a monster template used to instantiate combat monsters.
/// </summary>
public record MonsterTemplateDto
{
    /// <summary>
    /// The template identifier.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// The base name of the monster template.
    /// </summary>
    public string BaseName { get; set; } = null!;

    /// <summary>
    /// Maximum hit points for monsters created from this template.
    /// </summary>
    public int MaxHp { get; set; }

    /// <summary>
    /// Armor class for the template.
    /// </summary>
    public int Ac { get; set; }

    /// <summary>
    /// Optional JSON payload containing additional template details.
    /// </summary>
    public string? DetailsJson { get; set; }
}