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
        IQueryable<Ticket> query = entities.AsQueryable();

        if (!string.IsNullOrEmpty(searchCriteria.Title))
            query = query.Where(e => e.Title.Equals(searchCriteria.Title, StringComparison.OrdinalIgnoreCase));

     if (!string.IsNullOrEmpty(searchCriteria.Description))
            query = query.Where(e => e.Title.Contains(searchCriteria.Description, StringComparison.OrdinalIgnoreCase));

        return query.ToList();

    }

    public IEnumerable<Ticket> Get(string searchText)
    {
        var query = entities.AsQueryable();

        query = query.Where(e => 
            e.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase)
         || e.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase));

        return query.ToList();


        
    }
}
