using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusArticle.Migrations
{
    public partial class InitMuseumD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Museums",
                columns: new[] { "MuseumId", "Name", "Theme" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Bellas Artes", "History" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "AssociatedMuseumId", "Name", "State" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "David Statue", "OK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Museums",
                keyColumn: "MuseumId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
