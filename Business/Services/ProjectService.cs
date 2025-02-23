using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository, ProjectFactory projectFactory)
{
    private readonly IProjectRepository _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
    private readonly ICustomerRepository _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    private readonly ProjectFactory _projectFactory = projectFactory ?? throw new ArgumentNullException(nameof(projectFactory));

    public async Task CreateProjectAsync(string? title, int customerId)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Projektets titel får inte vara tom.");
            return;
        }

        // Kontrollera om kund-ID är giltigt innan projekt skapas
        var existingCustomer = await _customerRepository.GetAsync(c => c.Id == customerId);
        if (existingCustomer == null)
        {
            Console.WriteLine($"Ogiltigt kund-ID: {customerId}. Projektet kunde inte skapas.");
            return;
        }

        var projectEntity = new ProjectEntity
        {
            Title = title,
            CustomerId = customerId,
            StartDate = DateTime.Now,
            StatusId = 1
        };

        await _projectRepository.CreateAsync(projectEntity);
        Console.WriteLine("Projekt skapades framgångsrikt.");
    }

    public async Task<ProjectModel?> GetProjectAsync(int projectId)
    {
        var projectEntity = await _projectRepository.GetAsync(p => p.Id == projectId);
        if (projectEntity == null)
            return null;

        return _projectFactory.Create(projectEntity);
    }

    public async Task<ProjectModel?> GetProjectByIdAsync(int projectId)
    {
        var projectEntity = await _projectRepository.GetAsync(p => p.Id == projectId);
        if (projectEntity == null)
        {
            Console.WriteLine("Projekt hittades inte.");
            return null!;
        }

        return _projectFactory.Create(projectEntity);
    }

    public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
    {
        // Hämta alla projekt från databasen
        var projectEntities = await _projectRepository.GetAsync();

        // Skriv ut antalet projekt som hittades för felsökning
        Console.WriteLine($"Antal projekt hittade: {projectEntities.Count()}");

        // Skriv ut detaljer för varje projekt
        foreach (var project in projectEntities)
        {
            Console.WriteLine($"Projekt ID: {project.Id}, Titel: {project.Title}, KundID: {project.CustomerId}");
        }

        // Om inga projekt hittades, skriv ut ett meddelande
        if (!projectEntities.Any())
        {
            Console.WriteLine("Inga projekt hittades i databasen.");
        }

        // Konvertera entiteter till modeller och returnera dem
        return projectEntities.Select(_projectFactory.Create);
    }
}
