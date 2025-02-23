using Business.Factories;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository)
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository ?? throw new ArgumentNullException(nameof(statusTypeRepository));


    public async Task<IEnumerable<StatusTypeModel>> GetStatusTypesAsync() 
    {
        var statusTypeEntities = await _statusTypeRepository.GetAsync();
        return statusTypeEntities.Select(StatusTypeFactory.Create);
    }

    public async Task<StatusTypeModel?> GetStatusTypeByIdAsync(int id)
    {
        var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
        return statusTypeEntity == null ? null : StatusTypeFactory.Create(statusTypeEntity);
    }

}
