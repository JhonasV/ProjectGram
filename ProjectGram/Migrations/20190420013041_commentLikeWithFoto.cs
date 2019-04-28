using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class commentLikeWithFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentLikeId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "CommentLikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentLikeId",
                table: "CommentLikes",
                column: "CommentLikeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_FotoId",
                table: "CommentLikes",
                column: "FotoId",
                unique: true,
                filter: "[FotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_CommentLikes_CommentLikeId",
                table: "CommentLikes",
                column: "CommentLikeId",
                principalTable: "CommentLikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_Foto_FotoId",
                table: "CommentLikes",
                column: "FotoId",
                principalTable: "Foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_CommentLikes_CommentLikeId",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Foto_FotoId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_CommentLikeId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_FotoId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "CommentLikeId",
                table: "CommentLikes");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "CommentLikes");
        }
    }
}
