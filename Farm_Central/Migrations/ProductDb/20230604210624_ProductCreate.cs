using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farm_Central.Migrations.ProductDb
{
    /// <inheritdoc />
    public partial class ProductCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateManufactured",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FarmerName",
                table: "Products",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateManufactured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FarmerName",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactNum = table.Column<string>(type: "varchar(10)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmer_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
