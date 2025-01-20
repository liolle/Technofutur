using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tf2024_asp_razor.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicEntityPlaneTypeEntity");

            migrationBuilder.CreateTable(
                name: "MecanicEntityPlaneTypeEntity",
                columns: table => new
                {
                    HabilitationsId = table.Column<int>(type: "int", nullable: false),
                    MechanicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MecanicEntityPlaneTypeEntity", x => new { x.HabilitationsId, x.MechanicsId });
                    table.ForeignKey(
                        name: "FK_MecanicEntityPlaneTypeEntity_Mechanics_MechanicsId",
                        column: x => x.MechanicsId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MecanicEntityPlaneTypeEntity_PlaneType_HabilitationsId",
                        column: x => x.HabilitationsId,
                        principalTable: "PlaneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MecanicEntityPlaneTypeEntity_MechanicsId",
                table: "MecanicEntityPlaneTypeEntity",
                column: "MechanicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MecanicEntityPlaneTypeEntity");

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

            migrationBuilder.CreateIndex(
                name: "IX_MechanicEntityPlaneTypeEntity_MechanicsId",
                table: "MechanicEntityPlaneTypeEntity",
                column: "MechanicsId");
        }
    }
}
