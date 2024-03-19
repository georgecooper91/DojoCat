using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Parent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContactDetailsId",
                table: "Parent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
