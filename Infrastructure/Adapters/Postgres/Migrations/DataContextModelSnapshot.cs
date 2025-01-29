﻿// <auto-generated />
using System;
using Infrastructure.Adapters.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Adapters.Postgres.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.DrivingLicenceAggregate.DrivingLicense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<string>("CityOfBirth")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city_of_birth");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateOnly>("DateOfExpiry")
                        .HasColumnType("date")
                        .HasColumnName("date_of_expiry");

                    b.Property<DateOnly>("DateOfIssue")
                        .HasColumnType("date")
                        .HasColumnName("date_of_issue");

                    b.Property<int>("status_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("status_id");

                    b.ToTable("driving_license", (string)null);
                });

            modelBuilder.Entity("Core.Domain.DrivingLicenceAggregate.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "unprocessed"
                        },
                        new
                        {
                            Id = 2,
                            Name = "approved"
                        },
                        new
                        {
                            Id = 3,
                            Name = "rejected"
                        },
                        new
                        {
                            Id = 4,
                            Name = "expired"
                        });
                });

            modelBuilder.Entity("Core.Domain.PhotoAggregate.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BackPhotoStorageId")
                        .HasColumnType("uuid")
                        .HasColumnName("back_photo_storage_id");

                    b.Property<Guid>("DrivingLicenseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FrontPhotoStorageId")
                        .HasColumnType("uuid")
                        .HasColumnName("front_photo_storage_id");

                    b.HasKey("Id");

                    b.ToTable("photo", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Adapters.Postgres.Outbox.OutboxEvent", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("event_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("EventId");

                    b.ToTable("outbox", (string)null);
                });

            modelBuilder.Entity("Core.Domain.DrivingLicenceAggregate.DrivingLicense", b =>
                {
                    b.HasOne("Core.Domain.DrivingLicenceAggregate.Status", "Status")
                        .WithMany()
                        .HasForeignKey("status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Core.Domain.SharedKernel.ValueObjects.CategoryList", "Categories", b1 =>
                        {
                            b1.Property<Guid>("DrivingLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<char[]>("Categories")
                                .IsRequired()
                                .HasColumnType("character(1)[]")
                                .HasColumnName("categories");

                            b1.HasKey("DrivingLicenseId");

                            b1.ToTable("driving_license");

                            b1.WithOwner()
                                .HasForeignKey("DrivingLicenseId");
                        });

                    b.OwnsOne("Core.Domain.SharedKernel.ValueObjects.CodeOfIssue", "CodeOfIssue", b1 =>
                        {
                            b1.Property<Guid>("DrivingLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("code_of_issue");

                            b1.HasKey("DrivingLicenseId");

                            b1.ToTable("driving_license");

                            b1.WithOwner()
                                .HasForeignKey("DrivingLicenseId");
                        });

                    b.OwnsOne("Core.Domain.SharedKernel.ValueObjects.DrivingLicenseNumber", "Number", b1 =>
                        {
                            b1.Property<Guid>("DrivingLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("number");

                            b1.HasKey("DrivingLicenseId");

                            b1.ToTable("driving_license");

                            b1.WithOwner()
                                .HasForeignKey("DrivingLicenseId");
                        });

                    b.OwnsOne("Core.Domain.SharedKernel.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("DrivingLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("last_name");

                            b1.Property<string>("Patronymic")
                                .HasColumnType("text")
                                .HasColumnName("patronymic");

                            b1.HasKey("DrivingLicenseId");

                            b1.ToTable("driving_license");

                            b1.WithOwner()
                                .HasForeignKey("DrivingLicenseId");
                        });

                    b.Navigation("Categories")
                        .IsRequired();

                    b.Navigation("CodeOfIssue")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Number")
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
