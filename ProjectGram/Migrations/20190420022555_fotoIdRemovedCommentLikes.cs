using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class fotoIdRemovedCommentLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Foto_FotoId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_FotoId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "CommentLikes");

            migrationBuilder.AddColumn<int>(
                name: "CommentLikesId",
                table: "Foto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_CommentLikesId",
                table: "Foto",
                column: "CommentLikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_CommentLikes_CommentLikesId",
                table: "Foto",
                column: "CommentLikesId",
                principalTable: "CommentLikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_CommentLikes_CommentLikesId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_CommentLikesId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "CommentLikesId",
                table: "Foto");

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_FotoId",
                table: "CommentLikes",
                column: "FotoId",
                unique: true,
                filter: "[FotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_Foto_FotoId",
                table: "CommentLikes",
                column: "FotoId",
                principalTable: "Foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
