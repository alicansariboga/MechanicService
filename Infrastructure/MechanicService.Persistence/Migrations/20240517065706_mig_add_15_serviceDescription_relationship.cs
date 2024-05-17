using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_15_serviceDescription_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "ServiceDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDescriptions_ServiceID",
                table: "ServiceDescriptions",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDescriptions_Services_ServiceID",
                table: "ServiceDescriptions",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDescriptions_Services_ServiceID",
                table: "ServiceDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_ServiceDescriptions_ServiceID",
                table: "ServiceDescriptions");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "ServiceDescriptions");
        }
    }
}
