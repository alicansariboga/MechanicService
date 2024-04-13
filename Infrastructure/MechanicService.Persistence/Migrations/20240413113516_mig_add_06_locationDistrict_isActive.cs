using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_06_locationDistrict_isActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LocationDistricts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LocationDistricts");
        }
    }
}
