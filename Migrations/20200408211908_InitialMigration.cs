using Microsoft.EntityFrameworkCore.Migrations;

namespace BankZdjecOlsztyn.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miejsca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    ZdiencieUrl = table.Column<string>(nullable: true),
                    MinniaturkaUrl = table.Column<string>(nullable: true),
                    szerokosc = table.Column<double>(nullable: false),
                    wysokosc = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miejsca", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miejsca");
        }
    }
}
