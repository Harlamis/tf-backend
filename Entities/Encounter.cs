public class Encounter
{
    public int Id {get; set;}

    public String Name {get; set;}

    public int CurrentRound {get; set;}

    public int? ActiveEncounterId {get; set;}

    public List<CombatMonster> Monsters {get; set;} = [];
}