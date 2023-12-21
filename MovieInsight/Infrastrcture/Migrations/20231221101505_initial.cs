using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcture.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActDob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActId);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    DirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirDob = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.DirId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovYear = table.Column<int>(type: "int", nullable: false),
                    MovTime = table.Column<int>(type: "int", nullable: false),
                    MovLang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovDtRel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovRelCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovId);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    RevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevDob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevPincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.RevId);
                });

            migrationBuilder.CreateTable(
                name: "MovieCast",
                columns: table => new
                {
                    ActId = table.Column<int>(type: "int", nullable: false),
                    MovId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCast", x => new { x.ActId, x.MovId });
                    table.ForeignKey(
                        name: "FK_MovieCast_Actors_ActId",
                        column: x => x.ActId,
                        principalTable: "Actors",
                        principalColumn: "ActId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_Movies_MovId",
                        column: x => x.MovId,
                        principalTable: "Movies",
                        principalColumn: "MovId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirection",
                columns: table => new
                {
                    DirId = table.Column<int>(type: "int", nullable: false),
                    MovId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirection", x => new { x.DirId, x.MovId });
                    table.ForeignKey(
                        name: "FK_MovieDirection_Directors_DirId",
                        column: x => x.DirId,
                        principalTable: "Directors",
                        principalColumn: "DirId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirection_Movies_MovId",
                        column: x => x.MovId,
                        principalTable: "Movies",
                        principalColumn: "MovId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovId = table.Column<int>(type: "int", nullable: false),
                    GenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovId, x.GenId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenId",
                        column: x => x.GenId,
                        principalTable: "Genres",
                        principalColumn: "GenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovId",
                        column: x => x.MovId,
                        principalTable: "Movies",
                        principalColumn: "MovId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    MovId = table.Column<int>(type: "int", nullable: false),
                    RevId = table.Column<int>(type: "int", nullable: false),
                    RevStars = table.Column<int>(type: "int", nullable: false),
                    NumOfRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.MovId, x.RevId });
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovId",
                        column: x => x.MovId,
                        principalTable: "Movies",
                        principalColumn: "MovId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Reviewers_RevId",
                        column: x => x.RevId,
                        principalTable: "Reviewers",
                        principalColumn: "RevId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovId",
                table: "MovieCast",
                column: "MovId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirection_MovId",
                table: "MovieDirection",
                column: "MovId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenId",
                table: "MovieGenres",
                column: "GenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RevId",
                table: "Ratings",
                column: "RevId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCast");

            migrationBuilder.DropTable(
                name: "MovieDirection");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Reviewers");
        }
    }
}
