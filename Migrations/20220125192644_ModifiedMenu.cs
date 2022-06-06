using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_Project.Migrations
{
    public partial class ModifiedMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeverageId",
                table: "Menus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_BeverageId",
                table: "Menus",
                column: "BeverageId",
                unique: true,
                filter: "[BeverageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Beverages_BeverageId",
                table: "Menus",
                column: "BeverageId",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Beverages_BeverageId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_BeverageId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "BeverageId",
                table: "Menus");
        }
    }
}
