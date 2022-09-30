using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pais> Pais { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Lugar> Lugar { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) //Encargado de crear las Migraciones
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}