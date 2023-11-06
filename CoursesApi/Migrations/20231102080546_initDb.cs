using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesApi.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    instructor_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    bio = table.Column<string>(type: "longtext", nullable: false),
                    image_url = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.instructor_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    course_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    course_name = table.Column<string>(type: "longtext", nullable: false),
                    course_description = table.Column<string>(type: "longtext", nullable: false),
                    course_image_url = table.Column<string>(type: "longtext", nullable: false),
                    course_price = table.Column<int>(type: "int", nullable: false),
                    total_member = table.Column<int>(type: "int", nullable: false),
                    average_score_rating = table.Column<float>(type: "float", nullable: false),
                    total_rating = table.Column<int>(type: "int", nullable: false),
                    course_goal = table.Column<string>(type: "longtext", nullable: true),
                    course_created_at = table.Column<string>(type: "longtext", nullable: false),
                    instructor_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_courses_instructors_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "instructors",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_details",
                columns: table => new
                {
                    course_detail_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    course_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    course_detail_index = table.Column<int>(type: "int", nullable: false),
                    course_detail_name = table.Column<string>(type: "longtext", nullable: false),
                    total_lecture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_details", x => x.course_detail_id);
                    table.ForeignKey(
                        name: "FK_course_details_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    enrollment_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    uid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    course_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    enrollment_date = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "FK_enrollments_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    rating_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    uid = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    course_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    rating_score = table.Column<float>(type: "float", nullable: false),
                    comment = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.rating_id);
                    table.ForeignKey(
                        name: "FK_ratings_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lectures",
                columns: table => new
                {
                    lecture_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    lecture_index = table.Column<int>(type: "int", nullable: false),
                    lecture_title = table.Column<string>(type: "longtext", nullable: false),
                    content = table.Column<string>(type: "longtext", nullable: false),
                    video_url = table.Column<string>(type: "longtext", nullable: false),
                    course_detail_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lectures", x => x.lecture_id);
                    table.ForeignKey(
                        name: "FK_lectures_course_details_course_detail_id",
                        column: x => x.course_detail_id,
                        principalTable: "course_details",
                        principalColumn: "course_detail_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_course_details_course_id",
                table: "course_details",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_instructor_id",
                table: "courses",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_course_id",
                table: "enrollments",
                column: "course_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lectures_course_detail_id",
                table: "lectures",
                column: "course_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_course_id",
                table: "ratings",
                column: "course_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "lectures");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "course_details");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "instructors");
        }
    }
}
