using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegisteration.Migrations
{
    /// <inheritdoc />
    public partial class int3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardians");

            migrationBuilder.DropIndex(
                name: "IX_Emergencies_StudentId",
                table: "Emergencies");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_StudentId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardians",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_StudentId",
                table: "Emergencies",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_StudentId",
                table: "Contacts",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardians");

            migrationBuilder.DropIndex(
                name: "IX_Emergencies_StudentId",
                table: "Emergencies");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_StudentId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_StudentId",
                table: "Guardians",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Emergencies_StudentId",
                table: "Emergencies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_StudentId",
                table: "Contacts",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");
        }
    }
}
