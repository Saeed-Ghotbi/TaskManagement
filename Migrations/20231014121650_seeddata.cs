using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CDT", "Creator", "MDT", "Title" },
                values: new object[] { 1, new DateTime(2023, 10, 14, 15, 46, 50, 517, DateTimeKind.Local).AddTicks(2864), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "دیده نشده" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "CDT", "Creator", "MDT", "Title" },
                values: new object[] { 1, new DateTime(2023, 10, 14, 15, 46, 50, 517, DateTimeKind.Local).AddTicks(2844), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "فنی" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDT",
                value: new DateTime(2023, 10, 14, 15, 46, 50, 517, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDT",
                value: new DateTime(2023, 10, 14, 15, 46, 50, 517, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "AssignmentId", "CDT", "Description", "MDT", "Seen", "StatusId", "SubjectId", "Title" },
                values: new object[] { 1, 1, new DateTime(2023, 10, 14, 15, 46, 50, 517, DateTimeKind.Local).AddTicks(2821), "باگ صفحه ادمین هنگام لاگین مشکل دارد.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 1, "رفع باگ صفحه ادمین" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CDT",
                value: new DateTime(2023, 10, 14, 15, 0, 55, 333, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "CDT",
                value: new DateTime(2023, 10, 14, 15, 0, 55, 333, DateTimeKind.Local).AddTicks(2432));
        }
    }
}
