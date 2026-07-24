public interface IEncounterService
{
    public Task<EncounterDto?> GetEncounterByIdAsync(int id);

    public Task<List<EncounterDto>> GetAllEncountersAsync();

    public Task<int> CreateEncounterAsync(CreateEncounterDto dto);

    public Task UpdateEncounterAsync(UpdateEncounterDto dto);

    public Task DeleteEncounterAsync(int id);

}