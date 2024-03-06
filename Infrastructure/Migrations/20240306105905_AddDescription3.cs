using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescription3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AboutUsSection");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "AboutUsSection");

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "AboutUsSection",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description3",
                table: "AboutUsSection");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AboutUsSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "AboutUsSection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
