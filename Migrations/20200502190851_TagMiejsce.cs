using Microsoft.EntityFrameworkCore.Migrations;

namespace BankZdjecOlsztyn.Migrations
{
    public partial class TagMiejsce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Tagi",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagi", x => x.TagId);
                });

         
            migrationBuilder.CreateTable(
                name: "MiejscTagi",
                columns: table => new
                {
                    MiejsceId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejscTagi", x => new { x.TagId, x.MiejsceId });
                    table.ForeignKey(
                        name: "FK_MiejscTagi_Miejsca_MiejsceId",
                        column: x => x.MiejsceId,
                        principalTable: "Miejsca",
                        principalColumn: "MiejsceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiejscTagi_Tagi_TagId",
                        column: x => x.TagId,
                        principalTable: "Tagi",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiejscTagi_MiejsceId",
                table: "MiejscTagi",
                column: "MiejsceId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiejscTagi");

         

            migrationBuilder.DropTable(
                name: "Tagi");

        }
    }
}
