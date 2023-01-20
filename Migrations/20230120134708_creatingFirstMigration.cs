using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTasksAPI.Migrations
{
    /// <inheritdoc />
    public partial class creatingFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoTask",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTask", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(name: "Id_Usuario", type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DataCriacao = table.Column<DateTime>(name: "Data_Criacao", type: "datetime2", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(name: "Data_Finalizacao", type: "datetime2", nullable: true),
                    IdTipoTask = table.Column<int>(name: "Id_Tipo_Task", type: "int", nullable: false),
                    TipoTaskid = table.Column<Guid>(name: "Tipo_Taskid", type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TipoTask_Tipo_Taskid",
                        column: x => x.TipoTaskid,
                        principalTable: "TipoTask",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Tasks_User_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Tipo_Taskid",
                table: "Tasks",
                column: "Tipo_Taskid");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UsuarioId",
                table: "Tasks",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TipoTask");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
