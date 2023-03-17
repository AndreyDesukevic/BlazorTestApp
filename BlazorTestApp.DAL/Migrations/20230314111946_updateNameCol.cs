using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTestApp.DAL.Migrations
{
    public partial class updateNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decsription",
                table: "Orders",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Decsription");
        }
    }
}
