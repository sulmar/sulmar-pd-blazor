using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeTicketRepository : ITicketRepository
{
    public IEnumerable<Ticket> GetAll()
    {
        return new List<Ticket>
        {
            new Ticket { Id = 1, Title = "Lorem"},
            new Ticket { Id = 2, Title = "Ipsum"},
            new Ticket { Id = 3, Title = "Deres"},
            new Ticket { Id = 4, Title = "Veto"},
            new Ticket { Id = 5, Title = "Alfa"},
        };
    }
}
