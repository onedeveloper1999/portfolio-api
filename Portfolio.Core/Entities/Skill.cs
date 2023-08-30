namespace Portfolio.Core.Entities;
public class Skill : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public virtual ICollection<Project> Projects { get; set; } 
}
