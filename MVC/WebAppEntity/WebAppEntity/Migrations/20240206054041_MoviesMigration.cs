using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppEntity.Migrations
{
    public partial class MoviesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmIndustry",
                columns: table => new
                {
                    MId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StarCast = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmIndustry", x => x.MId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmIndustry");
        }
    }
}
