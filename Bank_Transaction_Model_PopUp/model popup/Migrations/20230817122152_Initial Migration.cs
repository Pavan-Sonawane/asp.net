using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model_popup.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Transaction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_number = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    IFSC_Code = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip_code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name_of_customer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Transaction_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");
        }
    }
}
