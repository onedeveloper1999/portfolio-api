namespace Portfolio.Core.Entities;
public class Project : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string TechnologiesUsed { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string GitHubLink { get; set; } = string.Empty;
    public string WebsiteLink { get; set; } = string.Empty;

    public virtual ICollection<Skill> Skills { get; set; }
}
