using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_UlkeVeBayraklar.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Renkler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenkAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renkler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulkeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulkeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UlkelerVeBayraklar",
                columns: table => new
                {
                    RenkId = table.Column<int>(type: "int", nullable: false),
                    UlkeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlkelerVeBayraklar", x => new { x.RenkId, x.UlkeId });
                    table.ForeignKey(
                        name: "FK_UlkelerVeBayraklar_Renkler_RenkId",
                        column: x => x.RenkId,
                        principalTable: "Renkler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlkelerVeBayraklar_Ulkeler_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Renkler",
                columns: new[] { "Id", "RenkAdi" },
                values: new object[,]
                {
                    { 1, "Siyah" },
                    { 2, "Kahverengi" },
                    { 3, "Gri" },
                    { 4, "Beyaz" },
                    { 5, "Sarı" },
                    { 6, "Pembe" },
                    { 7, "Mor" },
                    { 8, "Mavi" },
                    { 9, "Yeşil" },
                    { 10, "Kırmızı" }
                });

            migrationBuilder.InsertData(
                table: "Ulkeler",
                columns: new[] { "Id", "UlkeAd" },
                values: new object[,]
                {
                    { 14, "Avusturya" },
                    { 15, "Kuzey Makedonya" },
                    { 16, "İskoçya" },
                    { 17, "Çekya" },
                    { 22, "Polonya" },
                    { 19, "Danimarka" },
                    { 20, "İspanya" },
                    { 21, "Macaristan" },
                    { 13, "Ukrayna" },
                    { 18, "İsviçre" },
                    { 12, "Hollanda" },
                    { 7, "Belçika" },
                    { 10, "Finlandiya" },
                    { 9, "Galler" },
                    { 8, "Hırvatistan" },
                    { 23, "İsveç" },
                    { 6, "İtalya" },
                    { 5, "Portekiz" },
                    { 4, "İngiltere" },
                    { 3, "Fransa" },
                    { 2, "Almanya" },
                    { 1, "Türkiye" },
                    { 11, "Rusya" },
                    { 24, "Slovakya" }
                });

            migrationBuilder.InsertData(
                table: "UlkelerVeBayraklar",
                columns: new[] { "RenkId", "UlkeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 10, 12 },
                    { 5, 13 },
                    { 8, 13 },
                    { 4, 14 },
                    { 10, 14 },
                    { 5, 15 },
                    { 10, 15 },
                    { 4, 16 },
                    { 8, 16 },
                    { 4, 17 },
                    { 8, 17 },
                    { 10, 17 },
                    { 8, 12 },
                    { 4, 18 },
                    { 4, 19 },
                    { 10, 19 },
                    { 5, 20 },
                    { 10, 20 },
                    { 4, 21 },
                    { 9, 21 },
                    { 10, 21 },
                    { 4, 22 },
                    { 10, 22 },
                    { 5, 23 },
                    { 8, 23 },
                    { 4, 24 },
                    { 10, 18 },
                    { 4, 12 },
                    { 10, 11 },
                    { 8, 11 },
                    { 10, 1 },
                    { 1, 2 },
                    { 5, 2 },
                    { 10, 2 },
                    { 4, 3 },
                    { 8, 3 },
                    { 10, 3 },
                    { 4, 4 },
                    { 8, 4 },
                    { 10, 4 },
                    { 9, 5 }
                });

            migrationBuilder.InsertData(
                table: "UlkelerVeBayraklar",
                columns: new[] { "RenkId", "UlkeId" },
                values: new object[,]
                {
                    { 10, 5 },
                    { 4, 6 },
                    { 9, 6 },
                    { 10, 6 },
                    { 1, 7 },
                    { 5, 7 },
                    { 10, 7 },
                    { 4, 8 },
                    { 8, 8 },
                    { 10, 8 },
                    { 4, 9 },
                    { 9, 9 },
                    { 10, 9 },
                    { 4, 10 },
                    { 8, 10 },
                    { 4, 11 },
                    { 8, 24 },
                    { 10, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UlkelerVeBayraklar_UlkeId",
                table: "UlkelerVeBayraklar",
                column: "UlkeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UlkelerVeBayraklar");

            migrationBuilder.DropTable(
                name: "Renkler");

            migrationBuilder.DropTable(
                name: "Ulkeler");
        }
    }
}
