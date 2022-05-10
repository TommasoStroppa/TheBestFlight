using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBestFlight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eleAssociazioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username_Utente = table.Column<string>(type: "TEXT", nullable: true),
                    ID_Tratta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eleAssociazioni", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "eleTratte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IATA_partenza = table.Column<string>(type: "TEXT", nullable: true),
                    IATA_destinazione = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eleTratte", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eleAssociazioni");

            migrationBuilder.DropTable(
                name: "eleTratte");
        }
    }
}
