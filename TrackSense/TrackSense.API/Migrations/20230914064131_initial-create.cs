using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackSense.API.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRidePoint_Location_LocationId1",
                table: "PlannedRidePoint");

            migrationBuilder.DropIndex(
                name: "IX_PlannedRidePoint_LocationId1",
                table: "PlannedRidePoint");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "PlannedRidePoint");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "PlannedRidePoint",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRidePoint_LocationId",
                table: "PlannedRidePoint",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRidePoint_Location_LocationId",
                table: "PlannedRidePoint",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRidePoint_Location_LocationId",
                table: "PlannedRidePoint");

            migrationBuilder.DropIndex(
                name: "IX_PlannedRidePoint_LocationId",
                table: "PlannedRidePoint");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "PlannedRidePoint",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LocationId1",
                table: "PlannedRidePoint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRidePoint_LocationId1",
                table: "PlannedRidePoint",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRidePoint_Location_LocationId1",
                table: "PlannedRidePoint",
                column: "LocationId1",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
