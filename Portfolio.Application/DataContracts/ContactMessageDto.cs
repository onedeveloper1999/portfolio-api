using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.DataContracts;
public record ContactMessageDto
{
    [Required]
    public int UserId { get; init; }

    [MaxLength(5)]
    public string Message { get; init; } = string.Empty;
}
