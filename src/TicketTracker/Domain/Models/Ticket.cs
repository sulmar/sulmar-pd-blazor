namespace Domain.Models;

public class Ticket : BaseEntity
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