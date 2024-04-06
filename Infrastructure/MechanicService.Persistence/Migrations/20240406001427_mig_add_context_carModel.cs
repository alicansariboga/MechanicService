using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_context_carModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarBrands_CarBrandId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CarBrandId",
                table: "CarModels");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandID",
                table: "CarModels",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarBrands_BrandID",
                table: "CarModels",
                column: "BrandID",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_CarBrands_BrandID",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_BrandID",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CarBrandId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_CarBrands_CarBrandId",
                table: "CarModels",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
