using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repository
{
    public static class QueryExtensions
    {
        public static IQueryable<T> MultipleInclude<T, TProperty>(this IQueryable<T> query, params Expression<Func<T, TProperty>>[] listIncludes) where T : class
        {
            foreach (var include in listIncludes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
