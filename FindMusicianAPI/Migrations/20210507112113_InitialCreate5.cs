using Microsoft.EntityFrameworkCore.Migrations;

namespace FindMusicianAPI.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Artist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Artist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
