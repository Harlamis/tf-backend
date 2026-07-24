public record UpdateEncounterDto
{
    public int Id { get; set; }

    public String? Name { get; set; }

    public int? CurrentRound { get; set; }

    public int? ActiveMonsterId { get; set; }
}