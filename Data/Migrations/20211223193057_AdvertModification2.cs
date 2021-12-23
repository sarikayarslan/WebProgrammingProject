using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProgrammingProject.Data.Migrations
{
    public partial class AdvertModification2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdvertisement");

            migrationBuilder.RenameColumn(
                name: "Explanation",
                table: "Advertisement",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Advertisement",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AspNetUsers_UserId",
                table: "Advertisement",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AspNetUsers_UserId",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Advertisement",
                newName: "Explanation");

            migrationBuilder.CreateTable(
                name: "UserAdvertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdvertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdvertisement_Advertisement_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdvertisement_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_AdvertisementId",
                table: "UserAdvertisement",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdvertisement_UserId",
                table: "UserAdvertisement",
                column: "UserId");
        }
    }
}
