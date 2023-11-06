using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    uid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    user_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false),
                    account = table.Column<string>(type: "longtext", nullable: false),
                    avatar = table.Column<string>(type: "longtext", nullable: false),
                    is_verified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    role = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.uid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    content = table.Column<string>(type: "longtext", nullable: false),
                    parent_comment_id = table.Column<string>(type: "longtext", nullable: true),
                    create_at = table.Column<string>(type: "longtext", nullable: false),
                    total_replies = table.Column<int>(type: "int", nullable: false),
                    uid_sending = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    lecture_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    uid_receiving = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    exercise_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_users_uid_receiving",
                        column: x => x.uid_receiving,
                        principalTable: "users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_users_uid_sending",
                        column: x => x.uid_sending,
                        principalTable: "users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_comments_uid_receiving",
                table: "comments",
                column: "uid_receiving");

            migrationBuilder.CreateIndex(
                name: "IX_comments_uid_sending",
                table: "comments",
                column: "uid_sending");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
