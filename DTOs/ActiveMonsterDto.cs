public record ActiveMonsterDto
{
    public int Id {get;set;}

    public int Init {get;set;}

    public int CurrentHp {get;set;}

    public int MaxHp {get;set;}

    public int Ac {get;set;}

    public string BaseName {get;set;} = null!;

    public string? CustomName {get;set;}

    public bool IsPlayer {get;set;}
}