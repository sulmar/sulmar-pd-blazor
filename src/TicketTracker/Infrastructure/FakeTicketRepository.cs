using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeTicketRepository : ITicketRepository
{
    public IEnumerable<Ticket> Get(TicketSearchCriteria searchCriteria)
    {
        throw new NotImplementedException();
    }

    public Ticket Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> GetAll()
    {
        return new List<Ticket>
        {
            new Ticket { Id = 1, Title = "Lorem", CreatedBy = "John"},
            new Ticket { Id = 2, Title = "Ipsum", CreatedBy = "Adam"},
            new Ticket { Id = 3, Title = "Deres", CreatedBy = "Kate" },
            new Ticket { Id = 4, Title = "Veto", CreatedBy = "Bob" },
            new Ticket { Id = 5, Title = "Alfa", CreatedBy = "John" },
        };
    }
}
