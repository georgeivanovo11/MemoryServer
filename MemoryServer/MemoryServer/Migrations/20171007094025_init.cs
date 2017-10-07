using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MemoryServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartOfSpeechSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfSpeechSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngWordSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartOfSpeechId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 25, nullable: false),
                    Transcription = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngWordSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngWordSet_PartOfSpeechSet_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartOfSpeechSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RusWordSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartOfSpeechId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RusWordSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RusWordSet_PartOfSpeechSet_PartOfSpeechId",
                        column: x => x.PartOfSpeechId,
                        principalTable: "PartOfSpeechSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngWordSet_PartOfSpeechId",
                table: "EngWordSet",
                column: "PartOfSpeechId");

            migrationBuilder.CreateIndex(
                name: "IX_RusWordSet_PartOfSpeechId",
                table: "RusWordSet",
                column: "PartOfSpeechId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngWordSet");

            migrationBuilder.DropTable(
                name: "RusWordSet");

            migrationBuilder.DropTable(
                name: "PartOfSpeechSet");
        }
    }
}
