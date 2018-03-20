using System.Collections.Generic;

namespace SharedToolBox.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetOnlyActive();
        void Update(int id, TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
