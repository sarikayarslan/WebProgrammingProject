using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class clubSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_PresidentNameId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "PresidentNameId",
                table: "Club",
                newName: "PresidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_PresidentNameId",
                table: "Club",
                newName: "IX_Club_PresidentId");

            migrationBuilder.AddColumn<string>(
                name: "PresidentEmail",
                table: "Club",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_PresidentId",
                table: "Club",
                column: "PresidentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_PresidentId",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "PresidentEmail",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "PresidentId",
                table: "Club",
                newName: "PresidentNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_PresidentId",
                table: "Club",
                newName: "IX_Club_PresidentNameId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Club",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_PresidentNameId",
                table: "Club",
                column: "PresidentNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
