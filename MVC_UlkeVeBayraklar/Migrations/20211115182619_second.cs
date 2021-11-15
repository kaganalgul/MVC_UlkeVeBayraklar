using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_UlkeVeBayraklar.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UlkeBayrak",
                table: "Ulkeler",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UlkeBayrak",
                table: "Ulkeler");
        }
    }
}
