using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Unimar.ProjetoAcademico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaCurso_e_Aluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Periodo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CargaHoraria = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeMaximaAlunos = table.Column<int>(type: "integer", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CursoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Aluno_TB_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aluno_CursoId",
                table: "TB_Aluno",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aluno");

            migrationBuilder.DropTable(
                name: "TB_Curso");
        }
    }
}
