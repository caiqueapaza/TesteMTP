using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteMTP.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_TASK",
                columns: table => new
                {
                    idTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false),
                    dtCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TASK", x => x.idTask);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TASK");
        }
    }
}
