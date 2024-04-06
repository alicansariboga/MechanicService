using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MechanicService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_context_rezervations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationCars_CarModels_CarModelId",
                table: "ReservationCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationCars_ReservationCarId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationPersons_ReservationPersonId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationServices_ReservationServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationCarId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationPersonId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ReservationCars_CarModelId",
                table: "ReservationCars");

            migrationBuilder.DropColumn(
                name: "ReservationCarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationPersonId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationServiceId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "ReservationCars");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RezCarID",
                table: "Reservations",
                column: "RezCarID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RezPersonID",
                table: "Reservations",
                column: "RezPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RezServiceID",
                table: "Reservations",
                column: "RezServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_ModelID",
                table: "ReservationCars",
                column: "ModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationCars_CarModels_ModelID",
                table: "ReservationCars",
                column: "ModelID",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationCars_RezCarID",
                table: "Reservations",
                column: "RezCarID",
                principalTable: "ReservationCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationPersons_RezPersonID",
                table: "Reservations",
                column: "RezPersonID",
                principalTable: "ReservationPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationServices_RezServiceID",
                table: "Reservations",
                column: "RezServiceID",
                principalTable: "ReservationServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationCars_CarModels_ModelID",
                table: "ReservationCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationCars_RezCarID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationPersons_RezPersonID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationServices_RezServiceID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RezCarID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RezPersonID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RezServiceID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ReservationCars_ModelID",
                table: "ReservationCars");

            migrationBuilder.AddColumn<int>(
                name: "ReservationCarId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationPersonId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationServiceId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "ReservationCars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationCarId",
                table: "Reservations",
                column: "ReservationCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationPersonId",
                table: "Reservations",
                column: "ReservationPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationServiceId",
                table: "Reservations",
                column: "ReservationServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationCars_CarModelId",
                table: "ReservationCars",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationCars_CarModels_CarModelId",
                table: "ReservationCars",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationCars_ReservationCarId",
                table: "Reservations",
                column: "ReservationCarId",
                principalTable: "ReservationCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationPersons_ReservationPersonId",
                table: "Reservations",
                column: "ReservationPersonId",
                principalTable: "ReservationPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationServices_ReservationServiceId",
                table: "Reservations",
                column: "ReservationServiceId",
                principalTable: "ReservationServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
