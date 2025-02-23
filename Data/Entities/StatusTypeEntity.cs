using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;

    //en status kan ha flera project//hjälp av chatgpt
    public virtual ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();

}
