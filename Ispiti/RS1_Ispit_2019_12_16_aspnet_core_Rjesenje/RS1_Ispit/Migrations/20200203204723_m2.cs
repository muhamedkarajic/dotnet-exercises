using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkolskaGodina",
                table: "PopravniIspit");

            migrationBuilder.AddColumn<int>(
                name: "SkolskaGodinaId",
                table: "PopravniIspit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_SkolskaGodinaId",
                table: "PopravniIspit",
                column: "SkolskaGodinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PopravniIspit_SkolskaGodina_SkolskaGodinaId",
                table: "PopravniIspit",
                column: "SkolskaGodinaId",
                principalTable: "SkolskaGodina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PopravniIspit_SkolskaGodina_SkolskaGodinaId",
                table: "PopravniIspit");

            migrationBuilder.DropIndex(
                name: "IX_PopravniIspit_SkolskaGodinaId",
                table: "PopravniIspit");

            migrationBuilder.DropColumn(
                name: "SkolskaGodinaId",
                table: "PopravniIspit");

            migrationBuilder.AddColumn<string>(
                name: "SkolskaGodina",
                table: "PopravniIspit",
                nullable: true);
        }
    }
}
