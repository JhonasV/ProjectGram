using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class addinApplicationUserChildClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Foto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Foto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Follows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Follows",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Followed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Followed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Archives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Archives",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ApplicationUserId1",
                table: "Likes",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_ApplicationUserId1",
                table: "Foto",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_ApplicationUserId1",
                table: "Follows",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Followed_ApplicationUserId1",
                table: "Followed",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_ApplicationUserId1",
                table: "CommentLikes",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_ApplicationUserId1",
                table: "Archives",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_AspNetUsers_ApplicationUserId1",
                table: "Archives",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_AspNetUsers_ApplicationUserId1",
                table: "CommentLikes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followed_AspNetUsers_ApplicationUserId1",
                table: "Followed",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId1",
                table: "Follows",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId1",
                table: "Foto",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_AspNetUsers_ApplicationUserId1",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_AspNetUsers_ApplicationUserId1",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Followed_AspNetUsers_ApplicationUserId1",
                table: "Followed");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId1",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId1",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Foto_ApplicationUserId1",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Follows_ApplicationUserId1",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Followed_ApplicationUserId1",
                table: "Followed");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_ApplicationUserId1",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Archives_ApplicationUserId1",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Followed");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Followed");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Archives");
        }
    }
}
