using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class followsFollowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
