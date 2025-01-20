using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tf2024_asp_razor.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaneType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<float>(type: "real", nullable: false),
                    NbPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mechanics_Taxable_Id",
                        column: x => x.Id,
                        principalTable: "Taxable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Licences = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilots_Taxable_Id",
                        column: x => x.Id,
                        principalTable: "Taxable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plane_PlaneType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PlaneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plane_Taxable_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Taxable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MechanicEntityPlaneTypeEntity",
                columns: table => new
                {
                    HabilitationsId = table.Column<int>(type: "int", nullable: false),
                    MechanicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicEntityPlaneTypeEntity", x => new { x.HabilitationsId, x.MechanicsId });
                    table.ForeignKey(
                        name: "FK_MechanicEntityPlaneTypeEntity_Mechanics_MechanicsId",
                        column: x => x.MechanicsId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicEntityPlaneTypeEntity_PlaneType_HabilitationsId",
                        column: x => x.HabilitationsId,
                        principalTable: "PlaneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    NbFlights = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => new { x.PilotId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_Flight_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_PlaneType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PlaneType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false),
                    ReparerId = table.Column<int>(type: "int", nullable: false),
                    CheckerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.CheckConstraint("CK_Maintenance_CheckerVerifier", "CheckerId != ReparerId");
                    table.ForeignKey(
                        name: "FK_Maintenance_Mechanics_CheckerId",
                        column: x => x.CheckerId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenance_Mechanics_ReparerId",
                        column: x => x.ReparerId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenance_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TypeId",
                table: "Flight",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CheckerId",
                table: "Maintenance",
                column: "CheckerId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_PlaneId",
                table: "Maintenance",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_ReparerId",
                table: "Maintenance",
                column: "ReparerId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicEntityPlaneTypeEntity_MechanicsId",
                table: "MechanicEntityPlaneTypeEntity",
                column: "MechanicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Plane_OwnerId",
                table: "Plane",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plane_TypeId",
                table: "Plane",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "MechanicEntityPlaneTypeEntity");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Plane");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "PlaneType");

            migrationBuilder.DropTable(
                name: "Taxable");
        }
    }
}
