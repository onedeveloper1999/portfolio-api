namespace Portfolio.Application.DataContracts;
public record ProjectDto
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string TechnologiesUsed { get; init; } = string.Empty;
    public string ImageUrl { get; init; } = string.Empty;
    public string GitHubLink { get; init; } = string.Empty;
    public string WebsiteLink { get; init; } = string.Empty;
}
