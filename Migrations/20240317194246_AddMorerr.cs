using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codegym_api.Migrations
{
    /// <inheritdoc />
    public partial class AddMorerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneArticles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoginDays",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "DoneArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoneArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoneArticles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginDays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoneArticles_UserId",
                table: "DoneArticles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginDays_UserId",
                table: "LoginDays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoneArticles");

            migrationBuilder.DropTable(
                name: "LoginDays");

            migrationBuilder.AddColumn<string>(
                name: "DoneArticles",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoginDays",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
