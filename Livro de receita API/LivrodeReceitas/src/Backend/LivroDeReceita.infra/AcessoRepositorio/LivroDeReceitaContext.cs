using LivroDeReceita.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.infra.AcessoRepositorio
{
    public class LivroDeReceitaContext : DbContext
    {

        public LivroDeReceitaContext(DbContextOptions<LivroDeReceitaContext> options) : base(options) 
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroDeReceitaContext).Assembly);
        }
    }
}
