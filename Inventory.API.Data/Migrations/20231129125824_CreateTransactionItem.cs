using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTransactionItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Items_ItemId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionStatuses_TransactionStatusId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ItemId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionStatusId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2840f4a-ecbb-4747-a4b8-d1d34ac44dc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2fa5204-fd76-4628-9339-c313a8097b5a");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionStatusId",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "ApiUserId",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f3c0c666-1f25-47f5-8c77-f9d5258ca472", null, "User", "USER" },
                    { "fb2e49d3-205f-4bd4-a2dc-394a46eaf083", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 29, 19, 58, 24, 565, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApiUserId",
                table: "Transactions",
                column: "ApiUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_ApiUserId",
                table: "Transactions",
                column: "ApiUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_ApiUserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ApiUserId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3c0c666-1f25-47f5-8c77-f9d5258ca472");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb2e49d3-205f-4bd4-a2dc-394a46eaf083");

            migrationBuilder.DropColumn(
                name: "ApiUserId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "TransactionStatusId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2840f4a-ecbb-4747-a4b8-d1d34ac44dc6", null, "Administrator", "ADMINISTRATOR" },
                    { "e2fa5204-fd76-4628-9339-c313a8097b5a", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 21, 12, 39, 326, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ItemId",
                table: "Transactions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionStatusId",
                table: "Transactions",
                column: "TransactionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Items_ItemId",
                table: "Transactions",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionStatuses_TransactionStatusId",
                table: "Transactions",
                column: "TransactionStatusId",
                principalTable: "TransactionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
