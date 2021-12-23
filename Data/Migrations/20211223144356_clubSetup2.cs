using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class clubSetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubUser_AspNetUsers_UserId1",
                table: "ClubUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdvertisement_AspNetUsers_UserId1",
                table: "UserAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_UserAdvertisement_UserId1",
                table: "UserAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_ClubUser_UserId1",
                table: "ClubUser");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserAdvertisement");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ClubUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAdvertisement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserAdvertisement",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClubUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_UserId",
                table: "UserAdvertisement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubUser_UserId",
                table: "ClubUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubUser_AspNetUsers_UserId",
                table: "ClubUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdvertisement_AspNetUsers_UserId",
                table: "UserAdvertisement",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubUser_AspNetUsers_UserId",
                table: "ClubUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdvertisement_AspNetUsers_UserId",
                table: "UserAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_UserAdvertisement_UserId",
                table: "UserAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_ClubUser_UserId",
                table: "ClubUser");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserAdvertisement");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdvertisement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserAdvertisement",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ClubUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ClubUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_UserId1",
                table: "UserAdvertisement",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ClubUser_UserId1",
                table: "ClubUser",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubUser_AspNetUsers_UserId1",
                table: "ClubUser",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdvertisement_AspNetUsers_UserId1",
                table: "UserAdvertisement",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
