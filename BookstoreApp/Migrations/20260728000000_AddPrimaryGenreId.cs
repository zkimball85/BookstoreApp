using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Database;

#nullable disable

namespace BookstoreApp.Migrations
{
    [DbContext(typeof(BookStoreDb))]
    [Migration("20260728000000_AddPrimaryGenreId")]
    public partial class AddPrimaryGenreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryGenreId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PrimaryGenreId",
                table: "Books",
                column: "PrimaryGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_PrimaryGenreId_Genres",
                table: "Books",
                column: "PrimaryGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_PrimaryGenreId_Genres",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PrimaryGenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PrimaryGenreId",
                table: "Books");
        }
    }
}
