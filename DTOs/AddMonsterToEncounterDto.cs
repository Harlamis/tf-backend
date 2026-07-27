public record AddMonsterToEncounterDto
{
    public string TemplateId { get; set; } = null!;

    public int EncounterId { get; set; }
}