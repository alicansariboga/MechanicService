using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_02_carBrand_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "CarBrands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "CarBrands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
