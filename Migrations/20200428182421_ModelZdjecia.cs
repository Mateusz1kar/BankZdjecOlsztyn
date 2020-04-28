using Microsoft.EntityFrameworkCore.Migrations;

namespace BankZdjecOlsztyn.Migrations
{
    public partial class ModelZdjecia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Miejsca");

            migrationBuilder.DropColumn(
                name: "MinniaturkaUrl",
                table: "Miejsca");

            migrationBuilder.DropColumn(
                name: "ZdiencieUrl",
                table: "Miejsca");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Miejsca",
                maxLength: 588,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Miejsca",
                maxLength: 188,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MiejsceId",
                table: "Miejsca",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca",
                column: "MiejsceId");

            migrationBuilder.CreateTable(
                name: "Zdjecia",
                columns: table => new
                {
                    ZdjecieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false),
                    MiejsceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecia", x => x.ZdjecieId);
                    table.ForeignKey(
                        name: "FK_Zdjecia_Miejsca_MiejsceId",
                        column: x => x.MiejsceId,
                        principalTable: "Miejsca",
                        principalColumn: "MiejsceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_MiejsceId",
                table: "Zdjecia",
                column: "MiejsceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zdjecia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca");

            migrationBuilder.DropColumn(
                name: "MiejsceId",
                table: "Miejsca");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Miejsca",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 588);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Miejsca",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 188);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Miejsca",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "MinniaturkaUrl",
                table: "Miejsca",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZdiencieUrl",
                table: "Miejsca",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miejsca",
                table: "Miejsca",
                column: "Id");
        }
    }
}
