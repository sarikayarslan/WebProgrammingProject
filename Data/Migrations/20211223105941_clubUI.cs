using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class clubUI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_UserId1",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Club",
                newName: "PresidentNameId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_UserId1",
                table: "Club",
                newName: "IX_Club_PresidentNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_PresidentNameId",
                table: "Club",
                column: "PresidentNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_PresidentNameId",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "PresidentNameId",
                table: "Club",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Club_PresidentNameId",
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
    }
}
