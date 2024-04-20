using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVerifiedCollumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Parent",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Parent");
        }
    }
}
