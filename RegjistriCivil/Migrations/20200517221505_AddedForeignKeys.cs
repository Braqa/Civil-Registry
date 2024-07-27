using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegjistriCivil.Migrations
{
    public partial class AddedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberWithRelation_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMemberWithRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMemberWithRelation",
                table: "FamilyMemberWithRelation");

            migrationBuilder.RenameTable(
                name: "FamilyMemberWithRelation",
                newName: "FamilyMemberBase");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMemberWithRelation_FamilyCertificateId",
                table: "FamilyMemberBase",
                newName: "IX_FamilyMemberBase_FamilyCertificateId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Passports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HusbandFatherId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HusbandId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HusbandMotherId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "MarriageCertificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WifeFatherId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WifeId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WifeMotherId",
                table: "MarriageCertificates",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdCardNumber",
                table: "IdCards",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "IdCards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "FamilyCertificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "FamilyCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "DeathCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "DeathCertificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "DeathCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "DeathCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpouseId",
                table: "DeathCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherDetailsId",
                table: "BirthCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherDetailsId",
                table: "BirthCertificates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "BirthCertificates",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Relation",
                table: "FamilyMemberBase",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalNumber",
                table: "FamilyMemberBase",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "FamilyMemberBase",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FamilyMemberBase",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMemberBase",
                table: "FamilyMemberBase",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PersonalNumber = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: true),
                    Employment = table.Column<string>(nullable: true),
                    SchoolQualification = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true),
                    Migration = table.Column<string>(nullable: true),
                    PlaceOfMigration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonStatistics_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PersonId",
                table: "Passports",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_HusbandFatherId",
                table: "MarriageCertificates",
                column: "HusbandFatherId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_HusbandId",
                table: "MarriageCertificates",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_HusbandMotherId",
                table: "MarriageCertificates",
                column: "HusbandMotherId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_WifeFatherId",
                table: "MarriageCertificates",
                column: "WifeFatherId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_WifeId",
                table: "MarriageCertificates",
                column: "WifeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageCertificates_WifeMotherId",
                table: "MarriageCertificates",
                column: "WifeMotherId");

            migrationBuilder.CreateIndex(
                name: "IX_IdCards_PersonId",
                table: "IdCards",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyCertificates_PersonId",
                table: "FamilyCertificates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathCertificates_FatherId",
                table: "DeathCertificates",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathCertificates_MotherId",
                table: "DeathCertificates",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathCertificates_PersonId",
                table: "DeathCertificates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathCertificates_SpouseId",
                table: "DeathCertificates",
                column: "SpouseId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_FatherDetailsId",
                table: "BirthCertificates",
                column: "FatherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_MotherDetailsId",
                table: "BirthCertificates",
                column: "MotherDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificates_PersonId",
                table: "BirthCertificates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStatistics_PersonId",
                table: "PersonStatistics",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_FatherDetailsId",
                table: "BirthCertificates",
                column: "FatherDetailsId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_MotherDetailsId",
                table: "BirthCertificates",
                column: "MotherDetailsId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_People_PersonId",
                table: "BirthCertificates",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_FatherId",
                table: "DeathCertificates",
                column: "FatherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_MotherId",
                table: "DeathCertificates",
                column: "MotherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_People_PersonId",
                table: "DeathCertificates",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_SpouseId",
                table: "DeathCertificates",
                column: "SpouseId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyCertificates_People_PersonId",
                table: "FamilyCertificates",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberBase_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMemberBase",
                column: "FamilyCertificateId",
                principalTable: "FamilyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdCards_People_PersonId",
                table: "IdCards",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandFatherId",
                table: "MarriageCertificates",
                column: "HusbandFatherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_People_HusbandId",
                table: "MarriageCertificates",
                column: "HusbandId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandMotherId",
                table: "MarriageCertificates",
                column: "HusbandMotherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeFatherId",
                table: "MarriageCertificates",
                column: "WifeFatherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_People_WifeId",
                table: "MarriageCertificates",
                column: "WifeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeMotherId",
                table: "MarriageCertificates",
                column: "WifeMotherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passports_People_PersonId",
                table: "Passports",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_FatherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_MotherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_People_PersonId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_FatherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_MotherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_People_PersonId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_SpouseId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyCertificates_People_PersonId",
                table: "FamilyCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberBase_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMemberBase");

            migrationBuilder.DropForeignKey(
                name: "FK_IdCards_People_PersonId",
                table: "IdCards");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_People_HusbandId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_People_WifeId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Passports_People_PersonId",
                table: "Passports");

            migrationBuilder.DropTable(
                name: "PersonStatistics");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Passports_PersonId",
                table: "Passports");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_HusbandFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_HusbandId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_HusbandMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_WifeFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_WifeId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_MarriageCertificates_WifeMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropIndex(
                name: "IX_IdCards_PersonId",
                table: "IdCards");

            migrationBuilder.DropIndex(
                name: "IX_FamilyCertificates_PersonId",
                table: "FamilyCertificates");

            migrationBuilder.DropIndex(
                name: "IX_DeathCertificates_FatherId",
                table: "DeathCertificates");

            migrationBuilder.DropIndex(
                name: "IX_DeathCertificates_MotherId",
                table: "DeathCertificates");

            migrationBuilder.DropIndex(
                name: "IX_DeathCertificates_PersonId",
                table: "DeathCertificates");

            migrationBuilder.DropIndex(
                name: "IX_DeathCertificates_SpouseId",
                table: "DeathCertificates");

            migrationBuilder.DropIndex(
                name: "IX_BirthCertificates_FatherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropIndex(
                name: "IX_BirthCertificates_MotherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropIndex(
                name: "IX_BirthCertificates_PersonId",
                table: "BirthCertificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMemberBase",
                table: "FamilyMemberBase");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "HusbandFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "HusbandId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "HusbandMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "WifeFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "WifeId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "WifeMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "IdCards");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "FamilyCertificates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "FamilyCertificates");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "DeathCertificates");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "DeathCertificates");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "DeathCertificates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DeathCertificates");

            migrationBuilder.DropColumn(
                name: "SpouseId",
                table: "DeathCertificates");

            migrationBuilder.DropColumn(
                name: "FatherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropColumn(
                name: "MotherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "BirthCertificates");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FamilyMemberBase");

            migrationBuilder.RenameTable(
                name: "FamilyMemberBase",
                newName: "FamilyMemberWithRelation");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMemberBase_FamilyCertificateId",
                table: "FamilyMemberWithRelation",
                newName: "IX_FamilyMemberWithRelation_FamilyCertificateId");

            migrationBuilder.AlterColumn<string>(
                name: "IdCardNumber",
                table: "IdCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Relation",
                table: "FamilyMemberWithRelation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalNumber",
                table: "FamilyMemberWithRelation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "FamilyMemberWithRelation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMemberWithRelation",
                table: "FamilyMemberWithRelation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMemberWithRelation_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMemberWithRelation",
                column: "FamilyCertificateId",
                principalTable: "FamilyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
