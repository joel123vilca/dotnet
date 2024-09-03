using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodEdo = table.Column<int>(type: "int", nullable: false),
                    Edo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodMun = table.Column<int>(type: "int", nullable: false),
                    Mun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesa = table.Column<int>(type: "int", nullable: false),
                    VotosValidos = table.Column<int>(type: "int", nullable: false),
                    VotosNulos = table.Column<int>(type: "int", nullable: false),
                    EG = table.Column<int>(type: "int", nullable: false),
                    NM = table.Column<int>(type: "int", nullable: false),
                    LM = table.Column<int>(type: "int", nullable: false),
                    JABE = table.Column<int>(type: "int", nullable: false),
                    JOBR = table.Column<int>(type: "int", nullable: false),
                    AE = table.Column<int>(type: "int", nullable: false),
                    CF = table.Column<int>(type: "int", nullable: false),
                    DC = table.Column<int>(type: "int", nullable: false),
                    EM = table.Column<int>(type: "int", nullable: false),
                    BERA = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    CodEdo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.CodEdo);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    CodMun = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodEdo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.CodMun);
                    table.ForeignKey(
                        name: "FK_Municipalities_States_CodEdo",
                        column: x => x.CodEdo,
                        principalTable: "States",
                        principalColumn: "CodEdo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parishes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodMun = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parishes", x => x.CodPar);
                    table.ForeignKey(
                        name: "FK_Parishes_Municipalities_CodMun",
                        column: x => x.CodMun,
                        principalTable: "Municipalities",
                        principalColumn: "CodMun",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingCenters",
                columns: table => new
                {
                    CentroCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingCenters", x => x.CentroCode);
                    table.ForeignKey(
                        name: "FK_VotingCenters_Parishes_CodPar",
                        column: x => x.CodPar,
                        principalTable: "Parishes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentroCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    VotosValidos = table.Column<int>(type: "int", nullable: false),
                    VotosNulos = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingTables_VotingCenters_CentroCode",
                        column: x => x.CentroCode,
                        principalTable: "VotingCenters",
                        principalColumn: "CentroCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VotingTableId = table.Column<int>(type: "int", nullable: false),
                    CandidateCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateVotes_VotingTables_VotingTableId",
                        column: x => x.VotingTableId,
                        principalTable: "VotingTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateVotes_VotingTableId_CandidateCode",
                table: "CandidateVotes",
                columns: new[] { "VotingTableId", "CandidateCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_CodEdo_CodMun",
                table: "Municipalities",
                columns: new[] { "CodEdo", "CodMun" });

            migrationBuilder.CreateIndex(
                name: "IX_Parishes_CodMun_CodPar",
                table: "Parishes",
                columns: new[] { "CodMun", "CodPar" });

            migrationBuilder.CreateIndex(
                name: "IX_States_CodEdo",
                table: "States",
                column: "CodEdo");

            migrationBuilder.CreateIndex(
                name: "IX_VotingCenters_CentroCode",
                table: "VotingCenters",
                column: "CentroCode");

            migrationBuilder.CreateIndex(
                name: "IX_VotingCenters_CodPar",
                table: "VotingCenters",
                column: "CodPar");

            migrationBuilder.CreateIndex(
                name: "IX_VotingTables_CentroCode",
                table: "VotingTables",
                column: "CentroCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateVotes");

            migrationBuilder.DropTable(
                name: "ElectionResults");

            migrationBuilder.DropTable(
                name: "VotingTables");

            migrationBuilder.DropTable(
                name: "VotingCenters");

            migrationBuilder.DropTable(
                name: "Parishes");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
