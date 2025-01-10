﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BucketQuestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BucketQuestAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250109121956_IntitialCreate")]
    partial class IntitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActivityTypeTrip", b =>
                {
                    b.Property<int>("ActivityTypesId")
                        .HasColumnType("integer");

                    b.Property<int>("TripsId")
                        .HasColumnType("integer");

                    b.HasKey("ActivityTypesId", "TripsId");

                    b.HasIndex("TripsId");

                    b.ToTable("ActivityTypeTrip");
                });

            modelBuilder.Entity("BucketQuestAPI.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BucketQuestAPI.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("TripId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("BucketQuestAPI.Entities.TripPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TripPackages");
                });

            modelBuilder.Entity("Entities.ActivityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Catatan")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("Itinerary")
                        .HasColumnType("text[]");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("TripPackageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TripPackageId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("ActivityTypeTrip", b =>
                {
                    b.HasOne("Entities.ActivityType", null)
                        .WithMany()
                        .HasForeignKey("ActivityTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BucketQuestAPI.Entities.Photo", b =>
                {
                    b.HasOne("Entities.Trip", null)
                        .WithMany("Photos")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("Entities.Trip", b =>
                {
                    b.HasOne("BucketQuestAPI.Entities.TripPackage", null)
                        .WithMany("Trips")
                        .HasForeignKey("TripPackageId");
                });

            modelBuilder.Entity("BucketQuestAPI.Entities.TripPackage", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Entities.Trip", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}