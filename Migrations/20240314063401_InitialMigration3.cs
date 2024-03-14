using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CureWell.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecifications_Specializations_SpecializationCode1",
                table: "DoctorSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSpecifications_SpecializationCode1",
                table: "DoctorSpecifications");

            migrationBuilder.DropColumn(
                name: "SurgeryCategory",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "SpecializationCode1",
                table: "DoctorSpecifications");

            migrationBuilder.AddColumn<string>(
                name: "SpecializationCode",
                table: "Surgeries",
                type: "varchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpecializationCode1",
                table: "Surgeries",
                type: "varchar(3)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SpecializationCode",
                table: "Specializations",
                type: "varchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_SpecializationCode1",
                table: "Surgeries",
                column: "SpecializationCode1");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecifications_SpecializationCode",
                table: "DoctorSpecifications",
                column: "SpecializationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecifications_Specializations_SpecializationCode",
                table: "DoctorSpecifications",
                column: "SpecializationCode",
                principalTable: "Specializations",
                principalColumn: "SpecializationCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surgeries_Specializations_SpecializationCode1",
                table: "Surgeries",
                column: "SpecializationCode1",
                principalTable: "Specializations",
                principalColumn: "SpecializationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecifications_Specializations_SpecializationCode",
                table: "DoctorSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Surgeries_Specializations_SpecializationCode1",
                table: "Surgeries");

            migrationBuilder.DropIndex(
                name: "IX_Surgeries_SpecializationCode1",
                table: "Surgeries");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSpecifications_SpecializationCode",
                table: "DoctorSpecifications");

            migrationBuilder.DropColumn(
                name: "SpecializationCode",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "SpecializationCode1",
                table: "Surgeries");

            migrationBuilder.AddColumn<string>(
                name: "SurgeryCategory",
                table: "Surgeries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationCode",
                table: "Specializations",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldMaxLength: 3)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationCode1",
                table: "DoctorSpecifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecifications_SpecializationCode1",
                table: "DoctorSpecifications",
                column: "SpecializationCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecifications_Specializations_SpecializationCode1",
                table: "DoctorSpecifications",
                column: "SpecializationCode1",
                principalTable: "Specializations",
                principalColumn: "SpecializationCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
