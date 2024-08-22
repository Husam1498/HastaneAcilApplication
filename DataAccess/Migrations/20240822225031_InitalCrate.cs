using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitalCrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alanlar",
                columns: table => new
                {
                    AlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alanlar", x => x.AlanId);
                });

            migrationBuilder.CreateTable(
                name: "DoktorLar",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorFUllname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorLar", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_DoktorLar_Alanlar_AlanId",
                        column: x => x.AlanId,
                        principalTable: "Alanlar",
                        principalColumn: "AlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    HastaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastlıkBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.HastaId);
                    table.ForeignKey(
                        name: "FK_Hastalar_DoktorLar_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "DoktorLar",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorLar_AlanId",
                table: "DoktorLar",
                column: "AlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Hastalar_DoktorId",
                table: "Hastalar",
                column: "DoktorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastalar");

            migrationBuilder.DropTable(
                name: "DoktorLar");

            migrationBuilder.DropTable(
                name: "Alanlar");
        }
    }
}
