namespace Domain.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class TicketSearchCriteria  : Base
{
     public string? Title { get; set; }
    public string? Description { get; set; }
     public TicketStatus? Status { get; set; }
     public DateTime? From { get; set; }
     public DateTime? To { get; set; }
}

public partial class Ticket : BaseEntity
{   
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public TicketStatus Status { get; set; }
}

public enum TicketStatus
{
    New,
    Assigned,
    Closed
}