﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyaiCoach.Persistance.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240502151533_mig_10")]
    partial class mig_10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyaiCoach.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TargetArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.SetRep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Rep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Set")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("SetReps");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.WorkoutDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Days")
                        .HasColumnType("integer");

                    b.Property<int>("DoesItWorks")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkoutSessionsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("WorkoutDays");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.WorkoutSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SetRepId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkoutDayId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("SetRepId");

                    b.HasIndex("WorkoutDayId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.WorkoutDay", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.AppUser", "AppUser")
                        .WithMany("WorkoutDays")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.WorkoutSession", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.Exercise", "Exercise")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyaiCoach.Domain.Entities.SetRep", "SetRep")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("SetRepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyaiCoach.Domain.Entities.WorkoutDay", "WorkoutDay")
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("WorkoutDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("SetRep");

                    b.Navigation("WorkoutDay");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("WorkoutDays");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Exercise", b =>
                {
                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.SetRep", b =>
                {
                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.WorkoutDay", b =>
                {
                    b.Navigation("WorkoutSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
