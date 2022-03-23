using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Azil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    kontaktTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    brZaposlenih = table.Column<int>(type: "int", nullable: false),
                    brZivotinja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Azil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    polZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brGodina = table.Column<int>(type: "int", nullable: false),
                    vrstaZ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KartonVakcinacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivVakcine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    datumVakcinacije = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartonVakcinacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Udomitelj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prezimeU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adresaU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    brTelefonaU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brLicneKarte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udomitelj", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    jmbg = table.Column<int>(type: "int", nullable: false),
                    slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzilID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zaposleni_Azil_AzilID",
                        column: x => x.AzilID,
                        principalTable: "Azil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zivotinja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    brKartonaVakc = table.Column<int>(type: "int", nullable: false),
                    brCipa = table.Column<int>(type: "int", nullable: false),
                    ZaposleniID = table.Column<int>(type: "int", nullable: true),
                    CipID = table.Column<int>(type: "int", nullable: true),
                    KartonVakcinacijeID = table.Column<int>(type: "int", nullable: true),
                    AzilID = table.Column<int>(type: "int", nullable: true),
                    UdomiteljID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zivotinja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zivotinja_Azil_AzilID",
                        column: x => x.AzilID,
                        principalTable: "Azil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zivotinja_Cip_CipID",
                        column: x => x.CipID,
                        principalTable: "Cip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zivotinja_KartonVakcinacije_KartonVakcinacijeID",
                        column: x => x.KartonVakcinacijeID,
                        principalTable: "KartonVakcinacije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zivotinja_Udomitelj_UdomiteljID",
                        column: x => x.UdomiteljID,
                        principalTable: "Udomitelj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zivotinja_Zaposleni_ZaposleniID",
                        column: x => x.ZaposleniID,
                        principalTable: "Zaposleni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleni_AzilID",
                table: "Zaposleni",
                column: "AzilID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinja_AzilID",
                table: "Zivotinja",
                column: "AzilID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinja_CipID",
                table: "Zivotinja",
                column: "CipID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinja_KartonVakcinacijeID",
                table: "Zivotinja",
                column: "KartonVakcinacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinja_UdomiteljID",
                table: "Zivotinja",
                column: "UdomiteljID");

            migrationBuilder.CreateIndex(
                name: "IX_Zivotinja_ZaposleniID",
                table: "Zivotinja",
                column: "ZaposleniID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zivotinja");

            migrationBuilder.DropTable(
                name: "Cip");

            migrationBuilder.DropTable(
                name: "KartonVakcinacije");

            migrationBuilder.DropTable(
                name: "Udomitelj");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Azil");
        }
    }
}
