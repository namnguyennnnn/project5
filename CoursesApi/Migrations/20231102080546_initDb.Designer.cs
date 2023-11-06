﻿// <auto-generated />
using CoursesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoursesApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231102080546_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CoursesApi.Model.CourseDetails", b =>
                {
                    b.Property<string>("course_detail_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<int>("course_detail_index")
                        .HasColumnType("int");

                    b.Property<string>("course_detail_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<int>("total_lecture")
                        .HasColumnType("int");

                    b.HasKey("course_detail_id");

                    b.HasIndex("course_id");

                    b.ToTable("course_details");
                });

            modelBuilder.Entity("CoursesApi.Model.Courses", b =>
                {
                    b.Property<string>("course_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<float>("average_score_rating")
                        .HasColumnType("float");

                    b.Property<string>("course_created_at")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_goal")
                        .HasColumnType("longtext");

                    b.Property<string>("course_image_url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("course_price")
                        .HasColumnType("int");

                    b.Property<string>("instructor_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<int>("total_member")
                        .HasColumnType("int");

                    b.Property<int>("total_rating")
                        .HasColumnType("int");

                    b.HasKey("course_id");

                    b.HasIndex("instructor_id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("CoursesApi.Model.Enrollments", b =>
                {
                    b.Property<string>("enrollment_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("course_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("enrollment_date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.HasKey("enrollment_id");

                    b.HasIndex("course_id")
                        .IsUnique();

                    b.ToTable("enrollments");
                });

            modelBuilder.Entity("CoursesApi.Model.Instructors", b =>
                {
                    b.Property<string>("instructor_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image_url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("instructor_id");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("CoursesApi.Model.Lectures", b =>
                {
                    b.Property<string>("lecture_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_detail_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<int>("lecture_index")
                        .HasColumnType("int");

                    b.Property<string>("lecture_title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("video_url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("lecture_id");

                    b.HasIndex("course_detail_id");

                    b.ToTable("lectures");
                });

            modelBuilder.Entity("CoursesApi.Model.Ratings", b =>
                {
                    b.Property<string>("rating_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("course_id")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<float>("rating_score")
                        .HasColumnType("float");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.HasKey("rating_id");

                    b.HasIndex("course_id");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("CoursesApi.Model.CourseDetails", b =>
                {
                    b.HasOne("CoursesApi.Model.Courses", "course")
                        .WithMany("courseDetails")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("CoursesApi.Model.Courses", b =>
                {
                    b.HasOne("CoursesApi.Model.Instructors", "instructor")
                        .WithMany("course")
                        .HasForeignKey("instructor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("CoursesApi.Model.Enrollments", b =>
                {
                    b.HasOne("CoursesApi.Model.Courses", "course")
                        .WithOne("enrollment")
                        .HasForeignKey("CoursesApi.Model.Enrollments", "course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("CoursesApi.Model.Lectures", b =>
                {
                    b.HasOne("CoursesApi.Model.CourseDetails", "courseDetail")
                        .WithMany("lectures")
                        .HasForeignKey("course_detail_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courseDetail");
                });

            modelBuilder.Entity("CoursesApi.Model.Ratings", b =>
                {
                    b.HasOne("CoursesApi.Model.Courses", "course")
                        .WithMany("ratings")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");
                });

            modelBuilder.Entity("CoursesApi.Model.CourseDetails", b =>
                {
                    b.Navigation("lectures");
                });

            modelBuilder.Entity("CoursesApi.Model.Courses", b =>
                {
                    b.Navigation("courseDetails");

                    b.Navigation("enrollment")
                        .IsRequired();

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("CoursesApi.Model.Instructors", b =>
                {
                    b.Navigation("course");
                });
#pragma warning restore 612, 618
        }
    }
}
