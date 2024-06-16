using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_project_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class ABC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "department",
                table: "AspNetUsers");
        }
    }
}
