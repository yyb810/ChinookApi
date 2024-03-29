﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class EntityData<T> where T : class
    {
        protected T GetByPKCore(Expression<Func<T, bool>> predicate)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

        public int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                predicate = (x) => true;

            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Set<T>().Count(predicate);
            }
        }

        public T GetFirst(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                predicate = (x) => true;

            using (ChinookEntities context = new ChinookEntities())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

        public List<T> Get()
        {
            return GetCore<T>(null, null, false, null, null);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetCore<T>(predicate, null, false, null, null);
        }

        protected List<T> GetCore<O>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, O>> orderBy,
            bool ascending,
            int? take,
            int? skip)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                IQueryable<T> query = context.Set<T>();

                if (predicate != null)
                    query = query.Where(predicate);

                if (orderBy != null)
                {
                    if (ascending)
                        query = query.OrderBy(orderBy);
                    else
                        query = query.OrderByDescending(orderBy);
                }

                if (skip != null)
                    query = query.Skip(skip.Value);

                if (take != null)
                query = query.Take(take.Value);

                return query.ToList();
            }
        }

        public List<R> Select<R>(
            Expression<Func<T, R>> selector,
            Expression<Func<T, bool>> predicate = null)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                IQueryable<T> query = context.Set<T>();

                if (predicate != null)
                    query = query.Where(predicate);

                IQueryable<R> query2 = query.Select(selector);

                return query2.ToList();
            }
        }

        public virtual void Insert(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Set<T>().Add(entity);

                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(entity).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (ChinookEntities context = new ChinookEntities())
            {
                context.Entry(entity).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
