using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        DbContext Context { get; }
        IEnumerable<T> All();
        IEnumerable<T> All(params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> AllByDefault<TProperty>();
        IEnumerable<T> AllByDefault<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> AllActives<TProperty>();
        IEnumerable<T> AllActives<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> AllDeleted<TProperty>();
        IEnumerable<T> AllDeleted<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes);
        T GetById(object Id);
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        IEnumerable<T> Where(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> WhereWithDefault<TProperty>(Expression<Func<T, bool>> where);
        IEnumerable<T> WhereWithDefault<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> WhereActives<TProperty>(Expression<Func<T, bool>> where);
        IEnumerable<T> WhereActives<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> WhereDeleted<TProperty>(Expression<Func<T, bool>> where);
        IEnumerable<T> WhereDeleted<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes);
        T First(Expression<Func<T, bool>> first = null);
        T First(Expression<Func<T, bool>> first, params Expression<Func<T, dynamic>>[] listIncludes);
        T FirstWithDefault<TProperty>(Expression<Func<T, bool>> first = null);
        T FirstWithDefault<TProperty>(Expression<Func<T, bool>> first, params Expression<Func<T, dynamic>>[] listIncludes);
        T Single(Expression<Func<T, bool>> single);
        T Single(Expression<Func<T, bool>> single, params Expression<Func<T, dynamic>>[] listIncludes);
        T SingleWithDefault<TProperty>(Expression<Func<T, bool>> single);
        T SingleWithDefault<TProperty>(Expression<Func<T, bool>> single, params Expression<Func<T, dynamic>>[] listIncludes);
        IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
        IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc, params Expression<Func<T, dynamic>>[] listIncludes);

        bool Add(T entity);
        bool Update(T entity);
        bool Disactivate<TProperty>(TProperty Id);
        bool Activate<TProperty>(TProperty Id);
        bool Delete<TProperty>(T entity, bool isSoftDelete = true);
        bool Save();

        bool BeginTransaction();
        bool Commit();
        bool Rollback();
    }
}
