﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository
{
    public interface IGenericRepositoryOperation<T>
    {
        IEnumerable<T> GetAll();
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete (T entity);
        T GetById(int id);
        void Save();
        Task<T> GetById(int d, params Expression<Func<T, object>>[] includes);
    }
}
