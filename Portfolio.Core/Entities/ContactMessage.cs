namespace Portfolio.Core.Entities;
public class ContactMessage : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }

    public virtual User User { get; set; } = new();
}