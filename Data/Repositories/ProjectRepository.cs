using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DataContext _context = context;
   

    //  Testa Lazy Loading genom att hämta ett projekt utan .Include()//hjälp av chatgpt
    public ProjectEntity? GetProjectWithLazyLoading(int projectId)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);

        if (project != null)
        {
            Console.WriteLine($"Projekt: {project.Title}");
            Console.WriteLine($"Användare: {project.User.FirstName} {project.User.LastName}"); 
        }
        else
        {
            Console.WriteLine("Inget projekt hittades");
        }

        return project;
    }
    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        return await _context.Projects.FirstOrDefaultAsync(expression);
    }
}

