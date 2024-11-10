using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTPTInheritanceV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffSpecificProperty",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TravellerSpecificProperty",
                table: "Passengers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffSpecificProperty",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravellerSpecificProperty",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
