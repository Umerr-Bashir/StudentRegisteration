using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegisteration.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNICFrontImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNICBackImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatricCertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntermediateCertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BachelorCertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceCertificateUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StudentId",
                table: "Documents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Students");
        }
    }
}
