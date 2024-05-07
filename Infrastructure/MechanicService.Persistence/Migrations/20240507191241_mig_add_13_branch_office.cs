using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_13_branch_office : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchOffices_LocationDistricts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "LocationDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_DistrictId",
                table: "BranchOffices",
                column: "DistrictId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchOffices");
        }
    }
}
