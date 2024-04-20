using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DojoCat.Members.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParentMemberRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_EmergencyContactId",
                table: "ContactDetails");

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
                    ParentReference = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Joined = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeleteParent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberParent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberParent", x => x.id);
                    table.ForeignKey(
                        name: "FK_MemberParent_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberParent_Parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_Username",
                table: "Members",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_EmergencyContactId",
                table: "ContactDetails",
                column: "EmergencyContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ParentId",
                table: "ContactDetails",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberParent_MemberId",
                table: "MemberParent",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberParent_ParentId",
                table: "MemberParent",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_Username",
                table: "Parent",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Parent_ParentId",
                table: "ContactDetails",
                column: "ParentId",
                principalTable: "Parent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Parent_ParentId",
                table: "ContactDetails");

            migrationBuilder.DropTable(
                name: "MemberParent");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropIndex(
                name: "IX_Members_Username",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_EmergencyContactId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ParentId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ContactDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_EmergencyContactId",
                table: "ContactDetails",
                column: "EmergencyContactId");
        }
    }
}
