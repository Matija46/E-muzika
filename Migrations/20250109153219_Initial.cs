using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Izvajalec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poslusalci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvajalec", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIzdaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzvajalecID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Album_Izvajalec_IzvajalecID",
                        column: x => x.IzvajalecID,
                        principalTable: "Izvajalec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    Dolzina = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pesem_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzvajalecPesem",
                columns: table => new
                {
                    IzvajalecID = table.Column<int>(type: "int", nullable: false),
                    PesemID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvajalecPesem", x => new { x.IzvajalecID, x.PesemID });
                    table.ForeignKey(
                        name: "FK_IzvajalecPesem_Izvajalec_IzvajalecID",
                        column: x => x.IzvajalecID,
                        principalTable: "Izvajalec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzvajalecPesem_Pesem_PesemID",
                        column: x => x.PesemID,
                        principalTable: "Pesem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IzvajalecID",
                table: "Album",
                column: "IzvajalecID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvajalecPesem_PesemID",
                table: "IzvajalecPesem",
                column: "PesemID");

            migrationBuilder.CreateIndex(
                name: "IX_Pesem_AlbumID",
                table: "Pesem",
                column: "AlbumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzvajalecPesem");

            migrationBuilder.DropTable(
                name: "Pesem");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Izvajalec");
        }
    }
}
