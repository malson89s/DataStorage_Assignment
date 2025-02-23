using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;

    //en kund kan ha flera projekt//hjälp av chatgpt
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];

}
