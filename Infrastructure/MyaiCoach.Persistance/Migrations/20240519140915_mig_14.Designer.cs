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
    [Migration("20240519140915_mig_14")]
    partial class mig_14
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

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Calory")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Carbonhydrate")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Protein")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Gram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Grams");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.NutritionDay", b =>
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

                    b.Property<Guid>("NutritionSessionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("NutritionDays");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.NutritionSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GramId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NutritionDayId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("GramId");

                    b.ToTable("NutritionSessions");
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

                    b.Property<Guid>("WorkoutSessionId")
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

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("NutritionDayNutritionSession", b =>
                {
                    b.Property<Guid>("NutritionDaysId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NutritionSessionsId")
                        .HasColumnType("uuid");

                    b.HasKey("NutritionDaysId", "NutritionSessionsId");

                    b.HasIndex("NutritionSessionsId");

                    b.ToTable("NutritionDayNutritionSession");
                });

            modelBuilder.Entity("WorkoutDayWorkoutSession", b =>
                {
                    b.Property<Guid>("WorkoutDaysId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutSessionsId")
                        .HasColumnType("uuid");

                    b.HasKey("WorkoutDaysId", "WorkoutSessionsId");

                    b.HasIndex("WorkoutSessionsId");

                    b.ToTable("WorkoutDayWorkoutSession");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.NutritionDay", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.NutritionSession", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.Food", "Fodd")
                        .WithMany("NutritionSessions")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyaiCoach.Domain.Entities.Gram", "Gram")
                        .WithMany("NutritionSessions")
                        .HasForeignKey("GramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fodd");

                    b.Navigation("Gram");
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

                    b.Navigation("Exercise");

                    b.Navigation("SetRep");
                });

            modelBuilder.Entity("NutritionDayNutritionSession", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.NutritionDay", null)
                        .WithMany()
                        .HasForeignKey("NutritionDaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyaiCoach.Domain.Entities.NutritionSession", null)
                        .WithMany()
                        .HasForeignKey("NutritionSessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkoutDayWorkoutSession", b =>
                {
                    b.HasOne("MyaiCoach.Domain.Entities.WorkoutDay", null)
                        .WithMany()
                        .HasForeignKey("WorkoutDaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyaiCoach.Domain.Entities.WorkoutSession", null)
                        .WithMany()
                        .HasForeignKey("WorkoutSessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("WorkoutDays");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Exercise", b =>
                {
                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Food", b =>
                {
                    b.Navigation("NutritionSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.Gram", b =>
                {
                    b.Navigation("NutritionSessions");
                });

            modelBuilder.Entity("MyaiCoach.Domain.Entities.SetRep", b =>
                {
                    b.Navigation("WorkoutSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
