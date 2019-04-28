using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectGram.Migrations
{
    public partial class identityServerAddedFollowBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Followed_UserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Usuario_UserId1",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_UserId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_UserId1",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Follows");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId",
                table: "Follows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Usuario_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Usuario_UserId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_UserId",
                table: "Follows");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Follows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId",
                table: "Follows",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_UserId1",
                table: "Follows",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Followed_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "Followed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Usuario_UserId1",
                table: "Follows",
                column: "UserId1",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
