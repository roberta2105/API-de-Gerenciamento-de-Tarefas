
using GerenciarTarefas.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciarTarefas.Api.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa")
            .HasKey(p => p.Id);

            builder.HasOne(p => p.Usuario)
            .WithMany()
            .HasForeignKey(fk => fk.IdUsuario);

            builder.Property(p => p.Titulo)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Descricao)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.StatusTarefa)
            .HasColumnType("VARCHAR")
            .IsRequired();
          
        }
    }
}