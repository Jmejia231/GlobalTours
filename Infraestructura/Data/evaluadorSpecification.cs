using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class evaluadorSpecification<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> espec)
        {
            var query = inputQuery;

            if (espec.Filtro != null)
            {
                query = query.Where(espec.Filtro); // p=>p.PaisId == 1
            }

            query = espec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}