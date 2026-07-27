/// <summary>
/// Request payload to update an encounter monster.
/// </summary>
public record UpdateMonsterDto
{
    /// <summary>
    /// Active monster identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Optional updated initiative.
    /// </summary>
    public int? Init { get; set; }

    /// <summary>
    /// Optional updated current hit points.
    /// </summary>
    public int? CurrentHp { get; set; }

    /// <summary>
    /// Optional updated maximum hit points.
    /// </summary>
    public int? MaxHp { get; set; }

    /// <summary>
    /// Optional updated armor class.
    /// </summary>
    public int? Ac { get; set; }

    /// <summary>
    /// Optional custom name.
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// Optional player character flag.
    /// </summary>
    public bool? IsPlayer { get; set; }
}