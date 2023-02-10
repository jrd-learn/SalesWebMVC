using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class FixedSalesRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Sellers_SellerId",
                table: "SalesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "SalesRecords");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerId",
                table: "SalesRecords",
                newName: "IX_SalesRecords_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecords",
                table: "SalesRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_Sellers_SellerId",
                table: "SalesRecords",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_Sellers_SellerId",
                table: "SalesRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecords",
                table: "SalesRecords");

            migrationBuilder.RenameTable(
                name: "SalesRecords",
                newName: "SalesRecord");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecords_SellerId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Sellers_SellerId",
                table: "SalesRecord",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
