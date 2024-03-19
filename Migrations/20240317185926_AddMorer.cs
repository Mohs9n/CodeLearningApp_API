using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codegym_api.Migrations
{
    /// <inheritdoc />
    public partial class AddMorer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoneArticles",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneArticles",
                table: "AspNetUsers");
        }
    }
}
