public class CombatMonster
{
    public int Id {get; set;}

    public string TemplateId {get; set;}

    public int CurrentHp {get; set;}

    public int Init {get; set;}

    public int EncounterId {get; set;}
    public Encounter Encounter {get; set;}
}