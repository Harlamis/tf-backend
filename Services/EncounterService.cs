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
            ActiveMonsterId = encounter.ActiveEncounterId,
            Monsters = encounter.Monsters.Select(m => new ActiveMonsterDto
            {
                Id = m.Id,
                Init = m.Init,
                CurrentHp = m.CurrentHp,
                IsPlayer = m.IsPlayer,
                CustomName = m.Name,
                BaseName = m.Template.BaseName,
                MaxHp = m.Template.maxHp,
                Ac = m.Template.Ac
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
            ActiveMonsterId = e.ActiveEncounterId,
            Monsters = e.Monsters.Select(m => new ActiveMonsterDto
            {
                Id = m.Id,
                Init = m.Init,
                CurrentHp = m.CurrentHp,
                IsPlayer = m.IsPlayer,
                CustomName = m.Name,
                BaseName = m.Template.BaseName,
                MaxHp = m.Template.maxHp,
                Ac = m.Template.Ac
            }).ToList()
        }).ToListAsync();
    }

    public async Task<int> CreateEncounterAsync(CreateEncounterDto dto)
    {
        Encounter encounter = new Encounter { CurrentRound = 1, ActiveEncounterId = null, Monsters = [], Name = dto.Name };

        _context.Encounters.Add(encounter);

        await _context.SaveChangesAsync();

        return encounter.Id;
    }
}