using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciarTarefas.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadadeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tarefa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    StatusTarefa = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tarefa_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_IdUsuario",
                table: "tarefa",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarefa");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
