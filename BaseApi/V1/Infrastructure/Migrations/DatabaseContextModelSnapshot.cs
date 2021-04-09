﻿// <auto-generated />
using System;
using BaseApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseApi.V1.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseApi.V1.Infrastructure.DatabaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("example_table");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Clients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HackneyId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.DayCarePackage", b =>
                {
                    b.Property<Guid>("DayCarePackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DayCarePackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("EscortNeeded")
                        .HasColumnType("bit");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<string>("HowLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowManyTimesPerMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFixedPeriodOrOngoing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsThisAnImmediateService")
                        .HasColumnType("bit");

                    b.Property<bool>("IsThisUserUnderS117")
                        .HasColumnType("bit");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<string>("NeedToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpportunitiesNeedToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<int>("TermTimeConsiderationOptionId")
                        .HasColumnType("int");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<bool>("TransportNeeded")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UpdaterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.HasKey("DayCarePackageId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PackageId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TermTimeConsiderationOptionId");

                    b.HasIndex("UpdaterId");

                    b.ToTable("DayCarePackages");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.HomeCarePackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFixedPeriod")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOngoingPeriod")
                        .HasColumnType("bit");

                    b.Property<bool>("IsThisAnImmediateService")
                        .HasColumnType("bit");

                    b.Property<bool>("IsThisuserUnderS117")
                        .HasColumnType("bit");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PackageId");

                    b.HasIndex("StatusId");

                    b.ToTable("HomeCarePackage");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.HomeCarePackageSlots", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HomeCarePackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InHours")
                        .HasColumnType("int");

                    b.Property<int>("InMinutes")
                        .HasColumnType("int");

                    b.Property<string>("NeedToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryCarer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryCarer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<Guid>("TimeSlotShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeSlotTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WhatShouldBeDone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TimeSlotShiftId");

                    b.HasIndex("TimeSlotTypeId");

                    b.ToTable("HomeCarePackageSlots");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PackageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.PackageServices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageServices");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.TermTimeConsiderationOption", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OptionId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OptionId");

                    b.ToTable("TermTimeConsiderationOptions");

                    b.HasData(
                        new
                        {
                            OptionId = 1,
                            OptionName = "N/A"
                        },
                        new
                        {
                            OptionId = 2,
                            OptionName = "Term Time"
                        },
                        new
                        {
                            OptionId = 3,
                            OptionName = "Holiday"
                        });
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.TimeSlotShifts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeSlotShiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimeSlotShifts");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.TimeSlotType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeSlotTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TimeSlotType");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HackneyId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.DayCarePackage", b =>
                {
                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Users", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.TermTimeConsiderationOption", "TermTimeConsiderationOption")
                        .WithMany()
                        .HasForeignKey("TermTimeConsiderationOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Users", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdaterId");
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.HomeCarePackage", b =>
                {
                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Clients", "Clients")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.HomeCarePackageSlots", b =>
                {
                    b.HasOne("BaseApi.V1.Infrastructure.Entities.PackageServices", "Services")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.TimeSlotShifts", "TimeSlotShift")
                        .WithMany()
                        .HasForeignKey("TimeSlotShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseApi.V1.Infrastructure.Entities.TimeSlotType", "TimeSlotTypes")
                        .WithMany()
                        .HasForeignKey("TimeSlotTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.PackageServices", b =>
                {
                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaseApi.V1.Infrastructure.Entities.Users", b =>
                {
                    b.HasOne("BaseApi.V1.Infrastructure.Entities.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
