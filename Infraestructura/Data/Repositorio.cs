using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public async Task<T> ObtenerAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> ObtenerEspec(ISpecification<T> espec)
        {
            return await AplicarSpecification(espec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosEspec(ISpecification<T> espec)
        {
            return await AplicarSpecification(espec).ToListAsync();
        }

        private IQueryable<T> AplicarSpecification(ISpecification<T> espec)
        {
            return evaluadorSpecification<T>.GetQuery(_db.Set<T>().AsQueryable(), espec);
        }
    }
}