using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercisesApi.Migrations
{
    public partial class InsertDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paragraph",
                table: "paragraphs");

            migrationBuilder.AddColumn<string>(
                name: "paragraph_url",
                table: "paragraphs",
                type: "longtext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paragraph_url",
                table: "paragraphs");

            migrationBuilder.AddColumn<string>(
                name: "paragraph",
                table: "paragraphs",
                type: "longtext",
                nullable: false);
        }
    }
}
