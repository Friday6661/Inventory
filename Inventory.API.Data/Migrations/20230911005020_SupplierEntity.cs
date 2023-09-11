using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SupplierEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<long>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupplierId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupplierId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "Description", "Email", "Name", "Telephone" },
                values: new object[] { 1, "Danger Line 001", "Seed Data", "supplier01@gmail.com", "Supplier-01", 8981216969L });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");
        }
    }
}
