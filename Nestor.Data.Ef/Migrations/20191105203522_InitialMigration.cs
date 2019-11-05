﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Nestor.Data.Ef.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nestor");

            migrationBuilder.CreateTable(
                name: "Pokemon",
                schema: "nestor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nest",
                schema: "nestor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HashtagName = table.Column<string>(nullable: true),
                    PokemonId = table.Column<int>(nullable: false),
                    NestType = table.Column<int>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    IsRecommended = table.Column<bool>(nullable: false),
                    LastMigration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nest_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalSchema: "nestor",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NestUpdate",
                schema: "nestor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NestId = table.Column<int>(nullable: false),
                    PokemonId = table.Column<int>(nullable: false),
                    MigrationNumber = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NestUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NestUpdate_Nest_PokemonId",
                        column: x => x.PokemonId,
                        principalSchema: "nestor",
                        principalTable: "Nest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NestUpdate_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalSchema: "nestor",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nest_PokemonId",
                schema: "nestor",
                table: "Nest",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_NestUpdate_PokemonId",
                schema: "nestor",
                table: "NestUpdate",
                column: "PokemonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NestUpdate",
                schema: "nestor");

            migrationBuilder.DropTable(
                name: "Nest",
                schema: "nestor");

            migrationBuilder.DropTable(
                name: "Pokemon",
                schema: "nestor");
        }
    }
}
