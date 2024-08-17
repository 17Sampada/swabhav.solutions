using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProj2InventoryManagementSys.Migrations
{
    /// <inheritdoc />
    public partial class addingAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryBranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionQuantity = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId");
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InventoryId",
                table: "Transactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Inventories_InventoryId",
                table: "Suppliers",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "InventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventories_InventoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Inventories_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Products");
        }
    }
}
