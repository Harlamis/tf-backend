public interface IEncounterService
{
    public Task<EncounterDto?> GetEncounterByIdAsync(int id);

    
}