using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class updateJobUserChart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobsUser_AspNetUsers_UserNameId",
                table: "JobsUser");

            migrationBuilder.DropIndex(
                name: "IX_JobsUser_UserNameId",
                table: "JobsUser");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "JobsUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JobsUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JobsUser_UserId",
                table: "JobsUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsUser_AspNetUsers_UserId",
                table: "JobsUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobsUser_AspNetUsers_UserId",
                table: "JobsUser");

            migrationBuilder.DropIndex(
                name: "IX_JobsUser_UserId",
                table: "JobsUser");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "JobsUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameId",
                table: "JobsUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobsUser_UserNameId",
                table: "JobsUser",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsUser_AspNetUsers_UserNameId",
                table: "JobsUser",
                column: "UserNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
