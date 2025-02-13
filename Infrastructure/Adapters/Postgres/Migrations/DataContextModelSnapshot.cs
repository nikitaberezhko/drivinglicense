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

            modelBuilder.Entity("Domain.DrivingLicenceAggregate.DrivingLicense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

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

            modelBuilder.Entity("Domain.DrivingLicenceAggregate.Status", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

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
                            Name = "pendingphotosadding"
                        },
                        new
                        {
                            Id = 2,
                            Name = "pendingprocessing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "approved"
                        },
                        new
                        {
                            Id = 4,
                            Name = "rejected"
                        },
                        new
                        {
                            Id = 5,
                            Name = "expired"
                        });
                });

            modelBuilder.Entity("Domain.PhotoAggregate.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BackPhotoStorageId")
                        .HasColumnType("uuid")
                        .HasColumnName("back_photo_storage_id");

                    b.Property<Guid>("DrivingLicenseId")
                        .HasColumnType("uuid")
                        .HasColumnName("driving_license_id");

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

            modelBuilder.Entity("Infrastructure.Adapters.S3.S3BucketModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bucket")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bucket");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("photos_s3_buckets", (string)null);
                });

            modelBuilder.Entity("Domain.DrivingLicenceAggregate.DrivingLicense", b =>
                {
                    b.HasOne("Domain.DrivingLicenceAggregate.Status", "Status")
                        .WithMany()
                        .HasForeignKey("status_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_status_id");

                    b.OwnsOne("Domain.SharedKernel.ValueObjects.CategoryList", "CategoryList", b1 =>
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

                    b.OwnsOne("Domain.SharedKernel.ValueObjects.City", "CityOfBirth", b1 =>
                        {
                            b1.Property<Guid>("DrivingLicenseId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("city_of_birth");

                            b1.HasKey("DrivingLicenseId");

                            b1.ToTable("driving_license");

                            b1.WithOwner()
                                .HasForeignKey("DrivingLicenseId");
                        });

                    b.OwnsOne("Domain.SharedKernel.ValueObjects.CodeOfIssue", "CodeOfIssue", b1 =>
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

                    b.OwnsOne("Domain.SharedKernel.ValueObjects.DrivingLicenseNumber", "Number", b1 =>
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

                    b.OwnsOne("Domain.SharedKernel.ValueObjects.Name", "Name", b1 =>
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

                    b.Navigation("CategoryList")
                        .IsRequired();

                    b.Navigation("CityOfBirth")
                        .IsRequired();

                    b.Navigation("CodeOfIssue")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Number")
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Infrastructure.Adapters.S3.S3BucketModel", b =>
                {
                    b.HasOne("Domain.PhotoAggregate.Photo", null)
                        .WithOne()
                        .HasForeignKey("Infrastructure.Adapters.S3.S3BucketModel", "PhotoId")
                        .HasConstraintName("fk_photos_s3_buckets_id");
                });
#pragma warning restore 612, 618
        }
    }
}
