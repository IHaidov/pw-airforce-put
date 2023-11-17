using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alesik.Haidov.Airforce.DBSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirbaseRelation",
                columns: table => new
                {
                    GUID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirbaseRelation", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "AircraftRelation",
                columns: table => new
                {
                    GUID = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    AirbaseGUID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftRelation", x => x.GUID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirbaseRelation");

            migrationBuilder.DropTable(
                name: "AircraftRelation");
        }
    }
}
