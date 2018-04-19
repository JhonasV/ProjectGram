using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class foto_album_2doIntento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Album_AlbumId",
                table: "Foto");

            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Usuario_UserId",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_UserId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Foto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Album_AlbumId",
                table: "Foto",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Album_AlbumId",
                table: "Foto");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Foto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Foto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_UserId",
                table: "Foto",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Album_AlbumId",
                table: "Foto",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Usuario_UserId",
                table: "Foto",
                column: "UserId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
