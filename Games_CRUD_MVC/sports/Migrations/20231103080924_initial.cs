using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sports.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_of_game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_of_game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coach_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
