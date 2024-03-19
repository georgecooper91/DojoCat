using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceEmergencyContactFromContactDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_ContactDetails_Id",
                table: "EmergencyContact");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "EmergencyContact");

            migrationBuilder.AddColumn<long>(
                name: "EmergencyContactId",
                table: "ContactDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_EmergencyContact_Id",
                table: "ContactDetails",
                column: "Id",
                principalTable: "EmergencyContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_EmergencyContact_Id",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "EmergencyContactId",
                table: "ContactDetails");

            migrationBuilder.AddColumn<long>(
                name: "ContactDetailsId",
                table: "EmergencyContact",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_ContactDetails_Id",
                table: "EmergencyContact",
                column: "Id",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
