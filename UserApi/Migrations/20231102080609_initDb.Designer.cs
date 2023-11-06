﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserApi.Data;

#nullable disable

namespace UserApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231102080609_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserApi.Model.Comment", b =>
                {
                    b.Property<string>("comment_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("create_at")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("exercise_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("lecture_id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("parent_comment_id")
                        .HasColumnType("longtext");

                    b.Property<int>("total_replies")
                        .HasColumnType("int");

                    b.Property<string>("uid_receiving")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("uid_sending")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.HasKey("comment_id");

                    b.HasIndex("uid_receiving");

                    b.HasIndex("uid_sending");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("UserApi.Model.User", b =>
                {
                    b.Property<string>("uid")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("account")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("is_verified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("role")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("uid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("UserApi.Model.Comment", b =>
                {
                    b.HasOne("UserApi.Model.User", "ReceivingUser")
                        .WithMany("ReceivedComments")
                        .HasForeignKey("uid_receiving")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UserApi.Model.User", "SendingUser")
                        .WithMany("SentComments")
                        .HasForeignKey("uid_sending")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceivingUser");

                    b.Navigation("SendingUser");
                });

            modelBuilder.Entity("UserApi.Model.User", b =>
                {
                    b.Navigation("ReceivedComments");

                    b.Navigation("SentComments");
                });
#pragma warning restore 612, 618
        }
    }
}
