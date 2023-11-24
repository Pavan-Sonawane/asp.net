using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Author.Migrations
{
    /// <inheritdoc />
    public partial class migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookQuantity",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookType",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookQuantity",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookType",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Authors");
        }
    }
}
