using Domain.Models;

namespace Domain.Abstractions;



public interface ITicketRepository
{
    IEnumerable<Ticket> GetAll();
}