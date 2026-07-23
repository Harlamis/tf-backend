public record EncounterDto
{
    public int Id {get;set;}

    public int CurrentRound {get;set;}

    public int? ActiveMonsterId {get;set;}

    public String Name {get;set;} = null!;

    public List<ActiveMonsterDto> Monsters = [];
}