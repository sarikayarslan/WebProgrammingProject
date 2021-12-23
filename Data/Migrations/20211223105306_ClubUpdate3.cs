using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class ClubUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_PresidentId1",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "PresidentId1",
                table: "Club",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "PresidentId",
                table: "Club",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_PresidentId1",
                table: "Club",
                newName: "IX_Club_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_UserId1",
                table: "Club",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_UserId1",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Club",
                newName: "PresidentId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Club",
                newName: "PresidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_UserId1",
                table: "Club",
                newName: "IX_Club_PresidentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_PresidentId1",
                table: "Club",
                column: "PresidentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
