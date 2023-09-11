using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inventory.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    UsedCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TotalStocks = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Ini adalah item yang memiliki Category Monitor", false, "Monitor" },
                    { 2, "Ini adalah item yang memiliki Category Laptop", false, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Address", "IsDeleted", "Name", "TotalCapacity", "UsedCapacity" },
                values: new object[] { 1, "Danger Line 001", false, "Warehouse-01", 5000, 45 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "IsDeleted", "ItemCategoryId", "ItemType", "Name", "TotalStocks", "WarehouseId" },
                values: new object[,]
                {
                    { 1, "Monitor LED 20 Inch", false, 1, 2, "Monitor United-Star", 25, 1 },
                    { 2, "Laptop Work Station tipe W-540", false, 2, 2, "Laptop Thinkpad", 20, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
