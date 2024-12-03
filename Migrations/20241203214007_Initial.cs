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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poslusalci = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvajalec", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pesem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dolzina = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IzvajalecPesem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzvajalecID = table.Column<int>(type: "int", nullable: false),
                    PesemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzvajalecPesem", x => x.ID);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzvajalecPesem_IzvajalecID",
                table: "IzvajalecPesem",
                column: "IzvajalecID");

            migrationBuilder.CreateIndex(
                name: "IX_IzvajalecPesem_PesemID",
                table: "IzvajalecPesem",
                column: "PesemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzvajalecPesem");

            migrationBuilder.DropTable(
                name: "Izvajalec");

            migrationBuilder.DropTable(
                name: "Pesem");
        }
    }
}
