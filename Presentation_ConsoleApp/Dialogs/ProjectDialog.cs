using Business.Services;

namespace Presentation_ConsoleApp.Dialogs;

public class ProjectDialog(ProjectService projectService)
{
    private readonly ProjectService _projectService = projectService;

    public async Task CreateNewProject() 
    {
        Console.Write("Enter Project Title: ");
        var title = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title)) 
        {
            Console.WriteLine("Project title cannot be empty.");
            Console.ReadKey();
            return;
        }
        Console.Write("Enter Customer ID for the project: ");
        if (!int.TryParse(Console.ReadLine(), out int customerId)) 
        {
            Console.WriteLine("Invalid Customer Id.");
            Console.ReadKey();
            return;
        }
        await _projectService.CreateProjectAsync(title, customerId);
        Console.WriteLine("Project created successfully.");
        Console.ReadKey();
    }
    public async Task GetAllProjects() 
    {
        var projects = await _projectService.GetProjectsAsync();

        Console.WriteLine("All Projects: ");
        foreach (var project in projects) 
        {
            Console.WriteLine($"ID: {project.Id}, Title: {project.Title}");
        }
        if (!projects.Any()) 
        {
            Console.WriteLine("No projects found.");
        }
        Console.ReadKey();
    }
}
