using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeTicketRepository : FakeEntityRepository<Ticket>, ITicketRepository
{
    public FakeTicketRepository(IEnumerable<Ticket> tickets) : base(tickets)
    {       
    }
    public IEnumerable<Ticket> Get(TicketSearchCriteria searchCriteria)
    {
        throw new NotImplementedException();
    }    
}
