using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveParentReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Parent_Id",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Parent_ParentId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropIndex(
                name: "IX_Members_ParentId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ContactDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "Members",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ContactDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeleteParent = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Joined = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ParentReference = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ParentId",
                table: "Members",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Parent_Id",
                table: "ContactDetails",
                column: "Id",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Parent_ParentId",
                table: "Members",
                column: "ParentId",
                principalTable: "Parent",
                principalColumn: "Id");
        }
    }
}
