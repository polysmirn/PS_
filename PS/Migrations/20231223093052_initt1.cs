using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Migrations
{
    /// <inheritdoc />
    public partial class initt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Orders",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Orders",
                newName: "Time");
        }
    }
}
