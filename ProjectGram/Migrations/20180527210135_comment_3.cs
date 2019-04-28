using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectGram.Migrations
{
    public partial class comment_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Foto_FotoId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "FotoId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Foto_FotoId",
                table: "Comment",
                column: "FotoId",
                principalTable: "Foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Foto_FotoId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "FotoId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Foto_FotoId",
                table: "Comment",
                column: "FotoId",
                principalTable: "Foto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
