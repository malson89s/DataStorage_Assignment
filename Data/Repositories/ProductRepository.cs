using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context) , IProductRepository
{
    private readonly DataContext _context = context;

public override async Task<IEnumerable<ProductEntity>> GetAsync()
{
    return await _context.Products.ToListAsync();
}
    public override async Task<ProductEntity?> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        return await _context.Products.FirstOrDefaultAsync(expression);
    }

}



//crud med här som standard (note)
    //public async Task<IEnumerable<ProductEntity>> GetAllWithCategoryAsync()
    //{
    //    var entities = await _context.Products.Include(x => x.Category).ToListAsync();
    //    return entities!;
    //}


//testa om lazyloading fungerar

//var project = context.Projects.FirstOrDefault(p => p.Id == 1);

//Console.WriteLine($"Projekt: {project.Title}");
//Console.WriteLine($"Användare: {project.User.FirstName} {project.User.LastName}");