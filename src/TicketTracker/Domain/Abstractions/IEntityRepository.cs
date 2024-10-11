using Domain.Models;

namespace Domain.Abstractions;

public interface IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
      IEnumerable<TEntity> GetAll();
      TEntity Get(int id);
      void Add(TEntity entity);
}
