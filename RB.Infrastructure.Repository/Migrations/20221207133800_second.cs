using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RB.Infrastructure.Repository.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HostedRides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignupMemberId = table.Column<int>(type: "int", nullable: false),
                    VehicleVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostedRides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HostedRides_Users_SignupMemberId",
                        column: x => x.SignupMemberId,
                        principalTable: "Users",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostedRides_Vehicles_VehicleVehicleId",
                        column: x => x.VehicleVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HostedRides_SignupMemberId",
                table: "HostedRides",
                column: "SignupMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_HostedRides_VehicleVehicleId",
                table: "HostedRides",
                column: "VehicleVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HostedRides");
        }
    }
}
