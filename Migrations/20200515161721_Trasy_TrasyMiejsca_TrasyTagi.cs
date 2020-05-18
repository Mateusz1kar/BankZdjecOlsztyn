using Microsoft.EntityFrameworkCore.Migrations;

namespace BankZdjecOlsztyn.Migrations
{
    public partial class Trasy_TrasyMiejsca_TrasyTagi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trasy",
                columns: table => new
                {
                    TrasaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaTrasy = table.Column<string>(maxLength: 100, nullable: false),
                    DlugoscTrasy = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trasy", x => x.TrasaID);
                });

            migrationBuilder.CreateTable(
                name: "TrasaMiejsca",
                columns: table => new
                {
                    MiejsceId = table.Column<int>(nullable: false),
                    TrasaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasaMiejsca", x => new { x.TrasaID, x.MiejsceId });
                    table.ForeignKey(
                        name: "FK_TrasaMiejsca_Miejsca_MiejsceId",
                        column: x => x.MiejsceId,
                        principalTable: "Miejsca",
                        principalColumn: "MiejsceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrasaMiejsca_Trasy_TrasaID",
                        column: x => x.TrasaID,
                        principalTable: "Trasy",
                        principalColumn: "TrasaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrasaTagi",
                columns: table => new
                {
                    TrasaID = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasaTagi", x => new { x.TrasaID, x.TagId });
                    table.ForeignKey(
                        name: "FK_TrasaTagi_Tagi_TagId",
                        column: x => x.TagId,
                        principalTable: "Tagi",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrasaTagi_Trasy_TrasaID",
                        column: x => x.TrasaID,
                        principalTable: "Trasy",
                        principalColumn: "TrasaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrasaMiejsca_MiejsceId",
                table: "TrasaMiejsca",
                column: "MiejsceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrasaTagi_TagId",
                table: "TrasaTagi",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrasaMiejsca");

            migrationBuilder.DropTable(
                name: "TrasaTagi");

            migrationBuilder.DropTable(
                name: "Trasy");
        }
    }
}
