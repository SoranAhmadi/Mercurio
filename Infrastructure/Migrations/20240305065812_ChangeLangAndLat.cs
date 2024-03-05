using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLangAndLat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Lat",
                table: "ContactUs",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Lan",
                table: "ContactUs",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Lat",
                table: "ContactUs",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "Lan",
                table: "ContactUs",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
