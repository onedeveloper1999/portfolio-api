namespace Portfolio.Core.Entities;
public class BaseEntity
{
    public DateTimeOffset CreatedOn { get; set; }
    public int CreatedByUserId { get; set; }
    public DateTimeOffset LastUpdatedOn { get; set; }
    public int LastUpdatedByUserId { get; set; }
}
