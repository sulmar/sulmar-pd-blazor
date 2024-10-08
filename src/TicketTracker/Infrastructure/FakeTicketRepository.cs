using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeUserRepository : IUserRepository
{
    public User Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }
}

public class FakeTicketRepository : ITicketRepository
{
    private readonly IEnumerable<Ticket> tickets;

    public FakeTicketRepository(IEnumerable<Ticket> tickets)
    {
        this.tickets = tickets; 
    }
    public IEnumerable<Ticket> Get(TicketSearchCriteria searchCriteria)
    {
        throw new NotImplementedException();
    }

    public Ticket Get(int id)
    {
        return tickets.SingleOrDefault(t => t.Id == id);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return tickets;        
    }
}
