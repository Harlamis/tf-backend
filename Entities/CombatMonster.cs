public class CombatMonster
{
    public int Id {get; set;}

    public string TemplateId {get; set;} = null!;

    public MonsterTemplate Template {get; set;} = null!;

    public int CurrentHp {get; set;}

    public int Init {get; set;}

    public int EncounterId {get; set;}
    public Encounter Encounter {get; set;} = null!;

    public bool IsPlayer {get;set;}

    public String? Name {get;set;}
}