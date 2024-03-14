using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CureWell.Migrations
{
    public partial class InitialMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecifications");

            migrationBuilder.CreateTable(
                name: "DoctorSpecializations",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    SpecializationCode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecializationDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializations", x => new { x.DoctorID, x.SpecializationCode });
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Specializations_SpecializationCode",
                        column: x => x.SpecializationCode,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationCode",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_SpecializationCode",
                table: "DoctorSpecializations",
                column: "SpecializationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecializations");

            migrationBuilder.CreateTable(
                name: "DoctorSpecifications",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    SpecializationCode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecializationDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecifications", x => new { x.DoctorID, x.SpecializationCode });
                    table.ForeignKey(
                        name: "FK_DoctorSpecifications_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecifications_Specializations_SpecializationCode",
                        column: x => x.SpecializationCode,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationCode",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecifications_SpecializationCode",
                table: "DoctorSpecifications",
                column: "SpecializationCode");
        }
    }
}
