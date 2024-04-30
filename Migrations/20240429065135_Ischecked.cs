using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitApp.Migrations
{
    /// <inheritdoc />
    public partial class Ischecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Fruits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Fruits");
        }
    }
}
