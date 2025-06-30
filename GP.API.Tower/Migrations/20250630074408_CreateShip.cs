using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GP.API.Tower.Migrations
{
    /// <inheritdoc />
    public partial class CreateShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    MMSI = table.Column<string>(type: "varchar(255)", nullable: false, comment: "MMSI")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Draught = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Flag = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BuildingDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    ModificationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ship", x => x.MMSI);
                },
                comment: "Ship")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ship");
        }
    }
}
