

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public IList<TEntity> GetOnlyActive()
        {
            return _serviceBase.GetOnlyActive();
        }

        public void Update(int id, TEntity obj)
        {
            _serviceBase.Update(id, obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _serviceBase.Find(predicate);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
