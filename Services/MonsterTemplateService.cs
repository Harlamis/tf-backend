using Microsoft.EntityFrameworkCore;

public class MonsterTemplateService : IMonsterTemplateService
{
    private readonly ApplicationDbContext _context;

    public MonsterTemplateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MonsterTemplateDto>> GetAllTemplatesAsync()
    {
        return await _context.Templates.Select(t => new MonsterTemplateDto
        {
            Id = t.Id,
            Ac = t.Ac,
            BaseName = t.BaseName,
            MaxHp = t.MaxHp,
            DetailsJson = t.DetailsJson
        }).ToListAsync();
    }
}