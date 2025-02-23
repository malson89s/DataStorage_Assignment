using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IProjectRepository : IBaseRepository<ProjectEntity>
{
    //Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> predicate);
    //Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression);
}


