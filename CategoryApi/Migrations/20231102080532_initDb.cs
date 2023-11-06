using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CategoryApi.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    category_name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category_details",
                columns: table => new
                {
                    category_detail_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    category_detail_name = table.Column<string>(type: "longtext", nullable: false),
                    category_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_details", x => x.category_detail_id);
                    table.ForeignKey(
                        name: "FK_category_details_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_category_details_category_id",
                table: "category_details",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_details");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
