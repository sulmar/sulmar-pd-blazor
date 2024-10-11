using System.Collections.ObjectModel;
using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ICollection<TEntity> entities;

    public FakeEntityRepository(IEnumerable<TEntity> entities) 
    => this.entities = new List<TEntity>(entities);

    public void Add(TEntity entity)
    {
        int id = entities.Max(p=>p.Id);
        entity.Id = ++id; 
        entities.Add(entity);
    }

    public TEntity Get(int id) => entities.SingleOrDefault(e => e.Id == id);

    public IEnumerable<TEntity> GetAll() => entities;
}
