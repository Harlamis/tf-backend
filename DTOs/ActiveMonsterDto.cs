/// <summary>
/// Represents an active monster inside an encounter.
/// </summary>
public record ActiveMonsterDto
{
    /// <summary>
    /// The active monster identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Initiative score for turn order.
    /// </summary>
    public int Init { get; set; }

    /// <summary>
    /// Current hit points.
    /// </summary>
    public int CurrentHp { get; set; }

    /// <summary>
    /// Maximum hit points.
    /// </summary>
    public int MaxHp { get; set; }

    /// <summary>
    /// Armor class.
    /// </summary>
    public int Ac { get; set; }

    /// <summary>
    /// Base template name.
    /// </summary>
    public string BaseName { get; set; } = null!;

    /// <summary>
    /// Optional custom name for the monster.
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// Whether this monster is a player character.
    /// </summary>
    public bool IsPlayer { get; set; }

    /// <summary>
    /// Optional JSON-serialized detail string.
    /// </summary>
    public string? JsonDetails { get; set; }
}