using Domain.Models;

namespace Domain.Abstractions;

public interface ITicketRepository : IEntityRepository<Ticket>
{
    IEnumerable<Ticket> Get(TicketSearchCriteria searchCriteria);

}
