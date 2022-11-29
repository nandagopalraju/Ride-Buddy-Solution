using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository
{
    public class GenericRepositoryOperations<T> : IGenericRepositoryOperation<T> where T:class
    {
        private readonly DbContext _Context;
        private readonly DbSet<T> _dbSet;

        IQueryable<T> query;
        T entity;
        
        public GenericRepositoryOperations(UserDbContext context)
        {
            _Context=context;
            _dbSet = _Context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = _dbSet;
                query = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
            }
            catch (SqlException ex)
            {

            }
            return query;
        }
        public void Add(T entity)
        {
            try
            {

                _dbSet.Add(entity);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _Context.SaveChanges();
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Save()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> result = _dbSet;
                query = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
                entity = _dbSet.Find();
                return entity;
            }
            catch (SqlException ex)
            {
                return null;
            }

        }

    }
}
