using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class userTableDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_AspNetUsers_ApplicationUserId1",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Archives_Usuario_UserId",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Usuario_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_AspNetUsers_ApplicationUserId1",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Usuario_UserId",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Followed_AspNetUsers_ApplicationUserId1",
                table: "Followed");

            migrationBuilder.DropForeignKey(
                name: "FK_Followed_Usuario_UserId",
                table: "Followed");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId1",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Usuario_UserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId1",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Usuario_UserId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Usuario_UserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
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
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Archives_ApplicationUserId1",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Followed");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Archives");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Likes",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Follows",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Follows",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Followed",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Followed",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "CommentLikes",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Archives",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ApplicationUserId",
                table: "Likes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_ApplicationUserId",
                table: "Foto",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_ApplicationUserId",
                table: "Follows",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followed_ApplicationUserId",
                table: "Followed",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_ApplicationUserId",
                table: "CommentLikes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_ApplicationUserId",
                table: "Archives",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_AspNetUsers_ApplicationUserId",
                table: "Archives",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_User_UserId",
                table: "Archives",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_AspNetUsers_ApplicationUserId",
                table: "CommentLikes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followed_AspNetUsers_ApplicationUserId",
                table: "Followed",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followed_User_UserId",
                table: "Followed",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId",
                table: "Follows",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_User_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId",
                table: "Foto",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_User_UserId",
                table: "Foto",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId",
                table: "Likes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_AspNetUsers_ApplicationUserId",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Archives_User_UserId",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_AspNetUsers_ApplicationUserId",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Followed_AspNetUsers_ApplicationUserId",
                table: "Followed");

            migrationBuilder.DropForeignKey(
                name: "FK_Followed_User_UserId",
                table: "Followed");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_User_UserId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_User_UserId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ApplicationUserId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Foto_ApplicationUserId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Follows_ApplicationUserId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Followed_ApplicationUserId",
                table: "Followed");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_ApplicationUserId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Archives_ApplicationUserId",
                table: "Archives");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Likes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Likes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Likes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Foto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Foto",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Follows",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Follows",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Follows",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Followed",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Followed",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Followed",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "CommentLikes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Archives",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Archives",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ApplicationUserId1",
                table: "Likes",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

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
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

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
                name: "FK_Archives_Usuario_UserId",
                table: "Archives",
                column: "UserId",
                principalTable: "Usuario",
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
                name: "FK_Comment_Usuario_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "Usuario",
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
                name: "FK_CommentLikes_Usuario_UserId",
                table: "CommentLikes",
                column: "UserId",
                principalTable: "Usuario",
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
                name: "FK_Followed_Usuario_UserId",
                table: "Followed",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId1",
                table: "Follows",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Usuario_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_AspNetUsers_ApplicationUserId1",
                table: "Foto",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Usuario_UserId",
                table: "Foto",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId1",
                table: "Likes",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Usuario_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
