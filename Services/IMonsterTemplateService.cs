public interface IMonsterTemplateService
{
    public Task<List<MonsterTemplateDto>> GetAllTemplatesAsync();
}