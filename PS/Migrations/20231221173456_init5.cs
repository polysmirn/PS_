using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Photographers_PhotographerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Photographers_PhotographerId",
                table: "Orders",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Photographers_PhotographerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Photographers_PhotographerId",
                table: "Orders",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
