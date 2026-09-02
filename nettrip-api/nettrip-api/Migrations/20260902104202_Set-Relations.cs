using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nettrip_api.Migrations
{
    /// <inheritdoc />
    public partial class SetRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_trips_BusId",
                table: "trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_RouteId",
                table: "trips",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_trips_buses_BusId",
                table: "trips",
                column: "BusId",
                principalTable: "buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_routes_RouteId",
                table: "trips",
                column: "RouteId",
                principalTable: "routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trips_buses_BusId",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_routes_RouteId",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_BusId",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_RouteId",
                table: "trips");
        }
    }
}
