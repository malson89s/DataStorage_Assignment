using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public ProjectModel Create(ProjectEntity entity)
    {
        return new ProjectModel
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CustomerName = entity.Customer?.CustomerName ?? "Okänd",
            StatusName = entity.Status?.StatusName ?? "Okänd",
            UserName = $"{entity.User?.FirstName} {entity.User?.LastName}",
            ProductName = entity.Product?.ProductName ?? "Okänd"
        };
    }
}
