﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SharedToolBox.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IList<TEntity> ListAll();
        void Update(int id, TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Dispose();
    }
}
