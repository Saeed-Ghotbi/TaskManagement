using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class initSaeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CDT = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FailedLogin = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CDT", "FailedLogin", "IsActive", "LastLogin", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 12, 18, 49, 17, 258, DateTimeKind.Local).AddTicks(8300), 0, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "saeed123" },
                    { 2, new DateTime(2023, 10, 12, 18, 49, 17, 258, DateTimeKind.Local).AddTicks(8315), 0, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amir123" }
                });

            migrationBuilder.InsertData(
                table: "ProfileUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "SaeedGhotbi@outlook.com", "Saeed", null, "Ghotbi", "09380883666", 1 },
                    { 2, "amirTarbaran@outlook.com", "Amir", null, "Tarbaran", "09154578541", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUser_UserId",
                table: "ProfileUser",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileUser");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
