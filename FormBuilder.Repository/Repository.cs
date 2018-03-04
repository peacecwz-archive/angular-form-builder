using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FormBuilder.Data;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FormBuilderDbContext dbContext;
        private DbSet<T> table;

        public Repository(FormBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.table = this.dbContext.Set<T>();
        }

        public DbSet<T> Table => this.table;

        public DbContext Context => this.dbContext;
        
        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public virtual IEnumerable<T> All()
        {
            return Table.AsEnumerable();
        }

        public virtual IEnumerable<T> All(params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).AsEnumerable();
        }

        public virtual bool BeginTransaction()
        {
            if (dbContext.Database.CurrentTransaction != null) return false;
            try
            {
                dbContext.Database.BeginTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Commit()
        {
            if (dbContext.Database.CurrentTransaction == null) return false;
            dbContext.Database.CommitTransaction();
            return true;
        }

        public virtual bool Delete<TProperty>(T entity, bool isSoftDelete = true)
        {
            if (!isSoftDelete)
                table.Remove(entity);
            else
            {
                (entity as BaseEntity<TProperty>).IsDeleted = isSoftDelete;
                dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            return Save();
        }

        public virtual T First(Expression<Func<T, bool>> first = null)
        {
            if (first != null)
                return table.FirstOrDefault(first);
            return table.FirstOrDefault();
        }

        public virtual T First(Expression<Func<T, bool>> first, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            if (listIncludes == null & first == null)
                return table.FirstOrDefault();
            else if (listIncludes == null & first != null)
                return table.FirstOrDefault(first);
            else if (listIncludes != null & first == null)
                return table.MultipleInclude(listIncludes).FirstOrDefault();
            else
                return Table.MultipleInclude(listIncludes).FirstOrDefault(first);
        }

        public virtual T FirstWithDefault<TProperty>(Expression<Func<T, bool>> first = null)
        {
            if (first != null)
                return table.Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).FirstOrDefault(first);
            return table.FirstOrDefault(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual T FirstWithDefault<TProperty>(Expression<Func<T, bool>> first = null, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            if (first != null)
                return table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).FirstOrDefault(first);
            return table.MultipleInclude(listIncludes).FirstOrDefault(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual T GetById(object Id)
        {
            return table.Find(Id);
        }
        
        public virtual IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return table.OrderByDescending(orderBy);
            return table.OrderBy(orderBy);
        }

        public virtual IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            if (isDesc)
                return table.MultipleInclude(listIncludes).OrderByDescending(orderBy);
            return table.MultipleInclude(listIncludes).OrderBy(orderBy);
        }

        public virtual bool Rollback()
        {
            if (dbContext.Database.CurrentTransaction == null) return false;
            dbContext.Database.RollbackTransaction();
            return false;
        }

        public virtual bool Save()
        {
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, (ex.InnerException != null) ? ex.InnerException.Message : "");
                return false;
            }
        }

        public virtual T Single(Expression<Func<T, bool>> single)
        {
            return table.SingleOrDefault(single);
        }

        public virtual T Single(Expression<Func<T, bool>> single, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).SingleOrDefault(single);
        }

        public virtual T SingleWithDefault<TProperty>(Expression<Func<T, bool>> single)
        {
            return table.Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).SingleOrDefault(single);
        }

        public virtual T SingleWithDefault<TProperty>(Expression<Func<T, bool>> single, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).SingleOrDefault(single);
        }

        public virtual bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> WhereWithDefault<TProperty>(Expression<Func<T, bool>> where)
        {
            return Table.Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> WhereWithDefault<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> AllByDefault<TProperty>()
        {
            return Table.Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual IEnumerable<T> AllByDefault<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return Table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive & !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual IEnumerable<T> AllActives<TProperty>()
        {
            return Table.Where(x => (x as BaseEntity<TProperty>).IsActive);
        }

        public virtual IEnumerable<T> AllActives<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return Table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive);
        }

        public virtual IEnumerable<T> AllDeleted<TProperty>()
        {
            return Table.Where(x => !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual IEnumerable<T> AllDeleted<TProperty>(params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return Table.MultipleInclude(listIncludes).Where(x => !(x as BaseEntity<TProperty>).IsDeleted);
        }

        public virtual IEnumerable<T> WhereActives<TProperty>(Expression<Func<T, bool>> where)
        {
            return Table.Where(x => (x as BaseEntity<TProperty>).IsActive).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> WhereActives<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsActive).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> WhereDeleted<TProperty>(Expression<Func<T, bool>> where)
        {
            return Table.Where(x => (x as BaseEntity<TProperty>).IsDeleted).Where(where).AsEnumerable();
        }

        public virtual IEnumerable<T> WhereDeleted<TProperty>(Expression<Func<T, bool>> where, params Expression<Func<T, dynamic>>[] listIncludes)
        {
            return table.MultipleInclude(listIncludes).Where(x => (x as BaseEntity<TProperty>).IsDeleted).Where(where).AsEnumerable();
        }

        public virtual bool Disactivate<TProperty>(TProperty Id)
        {
            var entity = GetById(Id);
            if (entity == null) return false;
            (entity as BaseEntity<TProperty>).IsActive = false;
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save();
        }

        public virtual bool Activate<TProperty>(TProperty Id)
        {
            var entity = GetById(Id);
            if (entity == null) return false;
            (entity as BaseEntity<TProperty>).IsActive = true;
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save();
        }

    }
}
