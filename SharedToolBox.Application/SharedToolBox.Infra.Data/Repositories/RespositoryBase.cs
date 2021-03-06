﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Infra.Data.Contexto;
using System.Linq.Expressions;


namespace SharedToolBox.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjetoModeloContext Db = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> ListAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        //public Expression<Func<TItem, bool>> IsActive()
        //{
        //    string name = this.charityName;
        //    string referenceNumber = this.referenceNumber;
        //    return p =>
        //        (string.IsNullOrEmpty(name) ||
        //            p.registeredName.ToLower().Contains(name.ToLower()) ||
        //            p.alias.ToLower().Contains(name.ToLower()) ||
        //            p.charityId.ToLower().Contains(name.ToLower())) &&
        //        (string.IsNullOrEmpty(referenceNumber) ||
        //            p.charityReference.ToLower().Contains(referenceNumber.ToLower()));
        //}


        //public Expression<Func<TItem, object>> SelectExpression<TItem>(string fieldName)
        //{
        //    var param = Expression.Parameter(typeof(TItem), "item");
        //    var field = Expression.Property(param, fieldName);
        //    return Expression.Lambda<Func<TItem, object>>(field,
        //        new ParameterExpression[] { param });
        //}


        public void Update(int id, TEntity obj)
        {
            var local = GetById(id);
            Db.Entry(local).State = EntityState.Detached;
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate).AsNoTracking();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
