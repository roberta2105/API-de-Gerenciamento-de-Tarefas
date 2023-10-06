using GerenciarTarefas.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GerenciarTarefas.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario")
            .HasKey(p => p.Id);

            builder.Property(p => p.Nome)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Senha)
            .HasColumnType("VARCHAR")
            .IsRequired();


        }

}
}