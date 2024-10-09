using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class TicketSearchCriteria  : Base
{
     public string? Title { get; set; }
    public string? Description { get; set; }
     public TicketStatus Status { get; set; }
     public DateTime? From { get; set; }
     public DateTime? To { get; set; }
     
}

public partial class Ticket : BaseEntity
{   
    [Required, MinLength(3), RegularExpression(@"^[Tt]+$")]
    public string Title { get; set; }

    [MinLength(3), MaxLength(200)]
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public TicketStatus Status { get; set; }

    public Ticket()
    {
        Status = TicketStatus.New;
    }
}

public enum TicketStatus
{
    New,
    Assigned,
    Closed
}