namespace Portfolio.Application.DataContracts;
public record ContactDto
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}
