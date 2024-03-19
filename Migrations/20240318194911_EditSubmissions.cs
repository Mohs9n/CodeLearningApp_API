using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codegym_api.Migrations
{
    /// <inheritdoc />
    public partial class EditSubmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "Submissions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Output",
                table: "Submissions");
        }
    }
}
