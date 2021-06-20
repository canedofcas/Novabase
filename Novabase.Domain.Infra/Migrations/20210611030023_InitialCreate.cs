using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novabase.Domain.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsoAlpha2 = table.Column<string>(nullable: true),
                    IsoAlpha3 = table.Column<string>(nullable: true),
                    NumericCode = table.Column<int>(nullable: false),
                    Cctld = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Initial = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdIndicatorType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_IndicatorTypes_IdIndicatorType",
                        column: x => x.IdIndicatorType,
                        principalTable: "IndicatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasValueToPay = table.Column<bool>(nullable: false),
                    TrackingCode = table.Column<string>(nullable: true),
                    CodeArea = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    IdSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Indicators_IdSize",
                        column: x => x.IdSize,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    InteractionDate = table.Column<DateTime>(nullable: false),
                    IdPackage = table.Column<int>(nullable: false),
                    IdTypeControl = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false),
                    IdPlaceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Packages_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Indicators_IdPlaceType",
                        column: x => x.IdPlaceType,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Indicators_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkpoints_Indicators_IdTypeControl",
                        column: x => x.IdTypeControl,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdPackage",
                table: "Checkpoints",
                column: "IdPackage");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdPlaceType",
                table: "Checkpoints",
                column: "IdPlaceType");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdStatus",
                table: "Checkpoints",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Checkpoints_IdTypeControl",
                table: "Checkpoints",
                column: "IdTypeControl");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_IdIndicatorType",
                table: "Indicators",
                column: "IdIndicatorType");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_IdSize",
                table: "Packages",
                column: "IdSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkpoints");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "IndicatorTypes");
        }
    }
}
