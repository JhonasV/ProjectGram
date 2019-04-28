using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class followsfollowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Followed_FollowedId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowedId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "FollowedId",
                table: "Follows");

            migrationBuilder.AddColumn<int>(
                name: "FollowsId",
                table: "Followed",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followed_FollowsId",
                table: "Followed",
                column: "FollowsId",
                unique: true,
                filter: "[FollowsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Followed_Follows_FollowsId",
                table: "Followed",
                column: "FollowsId",
                principalTable: "Follows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followed_Follows_FollowsId",
                table: "Followed");

            migrationBuilder.DropIndex(
                name: "IX_Followed_FollowsId",
                table: "Followed");

            migrationBuilder.DropColumn(
                name: "FollowsId",
                table: "Followed");

            migrationBuilder.AddColumn<int>(
                name: "FollowedId",
                table: "Follows",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowedId",
                table: "Follows",
                column: "FollowedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Followed_FollowedId",
                table: "Follows",
                column: "FollowedId",
                principalTable: "Followed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
