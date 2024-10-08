using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly IEnumerable<TEntity> entities;

    public FakeEntityRepository(IEnumerable<TEntity> entities)
    {
        this.entities = entities;
    }

    public TEntity Get(int id)
    {
        return entities.SingleOrDefault(e => e.Id == id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return entities;
    }
}
