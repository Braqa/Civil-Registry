using Microsoft.EntityFrameworkCore.Migrations;

namespace RegjistriCivil.Migrations
{
    public partial class AddedFamilyMembersSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_FatherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMemberBase_MotherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_FatherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_MotherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMemberBase_SpouseId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMemberBase_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMemberBase");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMemberBase",
                table: "FamilyMemberBase");

            migrationBuilder.RenameTable(
                name: "FamilyMemberBase",
                newName: "FamilyMembers");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMemberBase_FamilyCertificateId",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_FamilyCertificateId");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolQualification",
                table: "PersonStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Migration",
                table: "PersonStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HealthStatus",
                table: "PersonStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Employment",
                table: "PersonStatistics",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_FamilyMembers_FatherDetailsId",
                table: "BirthCertificates",
                column: "FatherDetailsId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_FamilyMembers_MotherDetailsId",
                table: "BirthCertificates",
                column: "MotherDetailsId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_FatherId",
                table: "DeathCertificates",
                column: "FatherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_MotherId",
                table: "DeathCertificates",
                column: "MotherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_SpouseId",
                table: "DeathCertificates",
                column: "SpouseId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMembers",
                column: "FamilyCertificateId",
                principalTable: "FamilyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_HusbandFatherId",
                table: "MarriageCertificates",
                column: "HusbandFatherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_HusbandMotherId",
                table: "MarriageCertificates",
                column: "HusbandMotherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_WifeFatherId",
                table: "MarriageCertificates",
                column: "WifeFatherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_WifeMotherId",
                table: "MarriageCertificates",
                column: "WifeMotherId",
                principalTable: "FamilyMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMembers_FatherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_FamilyMembers_MotherDetailsId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_FatherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_MotherId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeathCertificates_FamilyMembers_SpouseId",
                table: "DeathCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyCertificates_FamilyCertificateId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_HusbandFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_HusbandMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_WifeFatherId",
                table: "MarriageCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_MarriageCertificates_FamilyMembers_WifeMotherId",
                table: "MarriageCertificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "FamilyMembers",
                newName: "FamilyMemberBase");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_FamilyCertificateId",
                table: "FamilyMemberBase",
                newName: "IX_FamilyMemberBase_FamilyCertificateId");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolQualification",
                table: "PersonStatistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Migration",
                table: "PersonStatistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "HealthStatus",
                table: "PersonStatistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Employment",
                table: "PersonStatistics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMemberBase",
                table: "FamilyMemberBase",
                column: "Id");

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
                name: "FK_DeathCertificates_FamilyMemberBase_SpouseId",
                table: "DeathCertificates",
                column: "SpouseId",
                principalTable: "FamilyMemberBase",
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
                name: "FK_MarriageCertificates_FamilyMemberBase_HusbandFatherId",
                table: "MarriageCertificates",
                column: "HusbandFatherId",
                principalTable: "FamilyMemberBase",
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
                name: "FK_MarriageCertificates_FamilyMemberBase_WifeMotherId",
                table: "MarriageCertificates",
                column: "WifeMotherId",
                principalTable: "FamilyMemberBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
