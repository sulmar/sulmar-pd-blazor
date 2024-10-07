using Domain.Models;

namespace Domain.Abstractions;



public interface ITicketRepository : IEntityRepository<Ticket>
{
    IEnumerable<Ticket> Get(TicketSearchCriteria searchCriteria);

}

public interface IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
      IEnumerable<TEntity> GetAll();
      TEntity Get(int id);
}

public interface IUserRepository : IEntityRepository<User>
{

}