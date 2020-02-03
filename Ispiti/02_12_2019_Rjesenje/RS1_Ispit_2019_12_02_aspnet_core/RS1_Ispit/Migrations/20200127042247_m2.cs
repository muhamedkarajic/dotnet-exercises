using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopravniIspit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIspita = table.Column<DateTime>(nullable: false),
                    OdjeljenjeID = table.Column<int>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PopravniIspitStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bodovi = table.Column<double>(nullable: true),
                    OdjeljenjeStavkaId = table.Column<int>(nullable: false),
                    PopravniIspitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspitStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopravniIspitStavka_OdjeljenjeStavka_OdjeljenjeStavkaId",
                        column: x => x.OdjeljenjeStavkaId,
                        principalTable: "OdjeljenjeStavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PopravniIspitStavka_PopravniIspit_PopravniIspitId",
                        column: x => x.PopravniIspitId,
                        principalTable: "PopravniIspit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_OdjeljenjeID",
                table: "PopravniIspit",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_PredmetID",
                table: "PopravniIspit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitStavka_OdjeljenjeStavkaId",
                table: "PopravniIspitStavka",
                column: "OdjeljenjeStavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitStavka_PopravniIspitId",
                table: "PopravniIspitStavka",
                column: "PopravniIspitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopravniIspitStavka");

            migrationBuilder.DropTable(
                name: "PopravniIspit");
        }
    }
}
