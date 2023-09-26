using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercisesApi.Migrations
{
    public partial class updateDbv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    exercise_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    category_detail_id = table.Column<string>(type: "longtext", nullable: false),
                    title_of_exercise = table.Column<string>(type: "longtext", nullable: false),
                    exercise_description = table.Column<string>(type: "longtext", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.exercise_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "audio",
                columns: table => new
                {
                    audio_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    audio_url = table.Column<string>(type: "longtext", nullable: false),
                    part1 = table.Column<string>(type: "longtext", nullable: false),
                    part2 = table.Column<string>(type: "longtext", nullable: false),
                    part3 = table.Column<string>(type: "longtext", nullable: false),
                    part4 = table.Column<string>(type: "longtext", nullable: false),
                    exercise_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audio", x => x.audio_id);
                    table.ForeignKey(
                        name: "FK_audio_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    question_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    question_content = table.Column<string>(type: "longtext", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false),
                    paragraph = table.Column<string>(type: "longtext", nullable: true),
                    exercise_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_questions_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    answer_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    answer_explanation = table.Column<string>(type: "longtext", nullable: false),
                    a = table.Column<string>(type: "longtext", nullable: false),
                    b = table.Column<string>(type: "longtext", nullable: false),
                    c = table.Column<string>(type: "longtext", nullable: false),
                    d = table.Column<string>(type: "longtext", nullable: false),
                    corect_answer = table.Column<string>(type: "longtext", nullable: false),
                    question_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.answer_id);
                    table.ForeignKey(
                        name: "FK_answers_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    image_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    image_url = table.Column<string>(type: "longtext", nullable: false),
                    question_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_images_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_audio_exercise_id",
                table: "audio",
                column: "exercise_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_question_id",
                table: "images",
                column: "question_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_exercise_id",
                table: "questions",
                column: "exercise_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "audio");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "exercises");
        }
    }
}
