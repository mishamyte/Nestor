using Microsoft.EntityFrameworkCore.Migrations;

namespace Nestor.Data.Ef.Migrations
{
    public partial class FixedBadNestUpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NestUpdate_Nest_PokemonId",
                table: "NestUpdate");

            migrationBuilder.CreateIndex(
                name: "IX_NestUpdate_NestId",
                table: "NestUpdate",
                column: "NestId");

            migrationBuilder.AddForeignKey(
                name: "FK_NestUpdate_Nest_NestId",
                table: "NestUpdate",
                column: "NestId",
                principalTable: "Nest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NestUpdate_Nest_NestId",
                table: "NestUpdate");

            migrationBuilder.DropIndex(
                name: "IX_NestUpdate_NestId",
                table: "NestUpdate");

            migrationBuilder.AddForeignKey(
                name: "FK_NestUpdate_Nest_PokemonId",
                table: "NestUpdate",
                column: "PokemonId",
                principalTable: "Nest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
