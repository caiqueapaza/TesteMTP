using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteMTP.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "T_TASK");

            migrationBuilder.AddColumn<DateTime>(
                name: "dtTask",
                table: "T_TASK",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dtTask",
                table: "T_TASK");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "T_TASK",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
