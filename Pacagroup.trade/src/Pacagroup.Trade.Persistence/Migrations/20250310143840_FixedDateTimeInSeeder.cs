using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pacagroup.Trade.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedDateTimeInSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 0, DateTimeKind.Utc));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 641, DateTimeKind.Utc).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 641, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 641, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "TransactTime",
                value: new DateTime(2025, 3, 10, 14, 21, 53, 641, DateTimeKind.Utc).AddTicks(1882));
        }
    }
}
