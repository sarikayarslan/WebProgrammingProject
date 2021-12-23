using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class ClubUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClubName",
                table: "Club",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClubName",
                table: "Club");
        }
    }
}
