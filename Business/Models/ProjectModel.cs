namespace Business.Models;

public class ProjectModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string CustomerName { get; set; } = null!;
    public string StatusName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
}
