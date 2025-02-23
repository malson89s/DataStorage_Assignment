using Data.Entities;

namespace Data.Interfaces;

public interface IProductRepository : IBaseRepository<ProductEntity>
{
    //Task<IEnumerable<ProductEntity>> GetAsync();
}



//Task<IEnumerable<ProductEntity>> GetAllWithCategoryAsync();
