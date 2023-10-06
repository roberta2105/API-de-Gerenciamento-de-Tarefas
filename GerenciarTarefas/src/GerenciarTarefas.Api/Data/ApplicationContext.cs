
using Microsoft.EntityFrameworkCore;
using GerenciarTarefas.Api.Domain.Models;
using GerenciarTarefas.Api.Data.Mappings;

namespace GerenciarTarefas.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
       }
}