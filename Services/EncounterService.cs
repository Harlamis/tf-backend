using Microsoft.EntityFrameworkCore;

public class EncounterService : IEncounterService
{
    private readonly ApplicationDbContext _context;

    public EncounterService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<EncounterDto?> GetEncounterByIdAsync(int id)
    {
        var encounter = await _context.Encounters.Include(e => e.Monsters).ThenInclude(m => m.Template).FirstOrDefaultAsync(e => e.Id == id);
        if (encounter == null) return null;
        EncounterDto dto = new EncounterDto
        {
            Id = encounter.Id,
            Name = encounter.Name,
            CurrentRound = encounter.CurrentRound,
            ActiveMonsterId = encounter.ActiveMonsterId,
            Monsters = encounter.Monsters.Select(m => new ActiveMonsterDto
            {
                Id = m.Id,
                Init = m.Init,
                CurrentHp = m.CurrentHp,
                IsPlayer = m.IsPlayer,
                CustomName = m.Name,
                BaseName = m.Template.BaseName,
                TemplateId = m.TemplateId,
                MaxHp = m.MaxHp,
                Ac = m.Ac,
                JsonDetails = m.Template.DetailsJson
            }).ToList()
        };
        return dto;
    }

    public async Task<List<EncounterDto>> GetAllEncountersAsync()
    {
        return await _context.Encounters.Include(e => e.Monsters).ThenInclude(m => m.Template).Select(e => new EncounterDto
        {
            Id = e.Id,
            Name = e.Name,
            CurrentRound = e.CurrentRound,
            ActiveMonsterId = e.ActiveMonsterId,
            Monsters = e.Monsters.Select(m => new ActiveMonsterDto
            {
                Id = m.Id,
                Init = m.Init,
                CurrentHp = m.CurrentHp,
                IsPlayer = m.IsPlayer,
                CustomName = m.Name,
                BaseName = m.Template.BaseName,
                TemplateId = m.TemplateId,
                MaxHp = m.MaxHp,
                Ac = m.Ac,
                JsonDetails = m.Template.DetailsJson
            }).ToList()
        }).ToListAsync();
    }

    public async Task<int> CreateEncounterAsync(CreateEncounterDto dto)
    {
        Encounter encounter = new Encounter { CurrentRound = 1, ActiveMonsterId = null, Monsters = [], Name = dto.Name };

        _context.Encounters.Add(encounter);

        await _context.SaveChangesAsync();

        return encounter.Id;
    }

    public async Task<bool> UpdateEncounterAsync(UpdateEncounterDto dto)
    {
        var original = await _context.Encounters.FirstOrDefaultAsync(e => e.Id == dto.Id);
        if (original == null) return false;
        original.Name = dto.Name ?? original.Name;
        original.ActiveMonsterId = dto.ActiveMonsterId ?? original.ActiveMonsterId;
        original.CurrentRound = dto.CurrentRound ?? original.CurrentRound;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteEncounterAsync(int id)
    {
        // var target = await _context.Encounters.FirstOrDefaultAsync(e => e.Id == id);
        // if (target == null) return;
        // _context.Encounters.Remove(target);
        // await _context.SaveChangesAsync();

        await _context.Encounters.Where(e => e.Id == id).ExecuteDeleteAsync();
    }

    public async Task<ActiveMonsterDto?> AddMonsterToEncounterAsync(AddMonsterToEncounterDto dto)
    {
        var template = await _context.Templates.FirstOrDefaultAsync(t => t.Id == dto.TemplateId);

        if (template == null) return null;

        CombatMonster newMonster = new CombatMonster
        {
            CurrentHp = template.MaxHp,
            MaxHp = template.MaxHp,
            Init = 0,
            TemplateId = template.Id,
            Ac = template.Ac,
            EncounterId = dto.EncounterId,
            IsPlayer = false,
            Name = template.BaseName
        };

        _context.CombatMonsters.Add(newMonster);

        await _context.SaveChangesAsync();

        return new ActiveMonsterDto
        {
            Id = newMonster.Id,
            Init = newMonster.Init,
            CurrentHp = newMonster.CurrentHp,
            MaxHp = newMonster.MaxHp,
            Ac = newMonster.Ac,
            IsPlayer = newMonster.IsPlayer,
            BaseName = template.BaseName,
            CustomName = newMonster.Name,
            JsonDetails = template.DetailsJson
        };
    }

    public async Task<bool> UpdateMonsterAsync(UpdateMonsterDto dto)
    {
        var original = await _context.CombatMonsters.FirstOrDefaultAsync(m => m.Id == dto.Id);

        if (original == null) return false;

        original.Ac = dto.Ac ?? original.Ac;
        original.CurrentHp = dto.CurrentHp ?? original.CurrentHp;
        original.Init = dto.Init ?? original.Init;
        original.MaxHp = dto.MaxHp ?? original.MaxHp;
        original.Name = dto.CustomName ?? original.Name;
        original.IsPlayer = dto.IsPlayer ?? original.IsPlayer;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteMonsterAsync(int id)
    {
        await _context.CombatMonsters.Where(m => m.Id == id).ExecuteDeleteAsync();
    }
}