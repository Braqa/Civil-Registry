using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegjistriCivil.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeathCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: false),
                    PlaceOfDeath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    IdCardNumber = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarriageCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    PlaceOfMarriage = table.Column<string>(nullable: true),
                    DateOfMarriage = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarriageCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentIssuingDate = table.Column<DateTime>(nullable: false),
                    DocumentIssuedBy = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    EyeColor = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMemberWithRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Relation = table.Column<int>(nullable: false),
                    PersonalNumber = table.Column<int>(nullable: false),
                    FamilyCertificateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMemberWithRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMemberWithRelation_FamilyCertificates_FamilyCertificateId",
                        column: x => x.FamilyCertificateId,
                        principalTable: "FamilyCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMemberWithRelation_FamilyCertificateId",
                table: "FamilyMemberWithRelation",
                column: "FamilyCertificateId");
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthCertificates");

            migrationBuilder.DropTable(
                name: "DeathCertificates");

            migrationBuilder.DropTable(
                name: "FamilyMemberWithRelation");

            migrationBuilder.DropTable(
                name: "IdCards");

            migrationBuilder.DropTable(
                name: "MarriageCertificates");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "FamilyCertificates");
        }
    }
}
