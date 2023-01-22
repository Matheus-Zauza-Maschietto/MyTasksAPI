using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTasksAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatingIdTypeColumnOfTipoTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TipoTask_TipoTaskid",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TipoTask",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoTaskid",
                table: "Tasks",
                newName: "TipoTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TipoTaskid",
                table: "Tasks",
                newName: "IX_Tasks_TipoTaskId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TipoTask",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TipoTaskId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TipoTask_TipoTaskId",
                table: "Tasks",
                column: "TipoTaskId",
                principalTable: "TipoTask",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TipoTask_TipoTaskId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoTask",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TipoTaskId",
                table: "Tasks",
                newName: "TipoTaskid");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TipoTaskId",
                table: "Tasks",
                newName: "IX_Tasks_TipoTaskid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "TipoTask",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoTaskid",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TipoTask_TipoTaskid",
                table: "Tasks",
                column: "TipoTaskid",
                principalTable: "TipoTask",
                principalColumn: "id");
        }
    }
}
