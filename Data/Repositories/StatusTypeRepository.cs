using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context) : BaseRepository<StatusTypeEntity>(context), IStatusTypeRepository
{
    private readonly DataContext _context = context;
    public override async Task<IEnumerable<StatusTypeEntity>> GetAsync()
    {
        return await _context.StatusTypes.ToListAsync();
    }

}



