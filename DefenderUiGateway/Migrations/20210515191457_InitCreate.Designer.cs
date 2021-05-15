﻿// <auto-generated />
using System;
using DefenderUiGateway.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenderUiGateway.Migrations
{
    [DbContext(typeof(DefenderDbContext))]
    [Migration("20210515191457_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DefenderUiGateway.Data.Model.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(7903),
                            Name = "МФО \"Копеечка онлайн\"",
                            RegistrationNumber = "8503708019",
                            Tin = "75034648"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(8904),
                            Name = "СберБанк",
                            RegistrationNumber = "1234143124",
                            Tin = "3434343"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(8908),
                            Name = "Тинькофф",
                            RegistrationNumber = "4536556456",
                            Tin = "45645645"
                        });
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InActionSince")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaidSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("UserId");

                    b.ToTable("Credits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankId = 2,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 586, DateTimeKind.Local).AddTicks(9540),
                            InActionSince = new DateTime(2021, 5, 5, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(13),
                            PaidSum = 0m,
                            Payment = 50000m,
                            PaymentDateTime = new DateTime(2021, 5, 10, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1385),
                            StateId = 1,
                            TotalSum = 200000m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BankId = 2,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1852),
                            InActionSince = new DateTime(2021, 5, 9, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1856),
                            PaidSum = 90000m,
                            Payment = 45000m,
                            PaymentDateTime = new DateTime(2021, 5, 12, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1859),
                            StateId = 0,
                            TotalSum = 500000m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BankId = 3,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1860),
                            InActionSince = new DateTime(2021, 5, 11, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1861),
                            PaidSum = 3000m,
                            Payment = 3000m,
                            PaymentDateTime = new DateTime(2021, 5, 13, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(1862),
                            StateId = 0,
                            TotalSum = 150000m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.CreditRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int?>("BkiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("BkiId")
                        .IsUnique()
                        .HasFilter("[BkiId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("CreditRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankId = 2,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(2453),
                            OrderDate = new DateTime(2021, 5, 10, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3201),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BankId = 2,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3456),
                            OrderDate = new DateTime(2021, 5, 12, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3458),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BankId = 3,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3459),
                            OrderDate = new DateTime(2021, 5, 13, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(3461),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.Push", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Pushed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pushes");
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RatingMax")
                        .HasColumnType("int");

                    b.Property<int>("RatingMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Passport")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 585, DateTimeKind.Local).AddTicks(1865),
                            CreditIndex = 707,
                            Name = "Сидоров Иван Петрович",
                            Passport = "1111222222",
                            Phone = "+7(123)1234567",
                            RatingMax = 850,
                            RatingMin = 300
                        });
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.UserLastPolling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastPolled")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Passport")
                        .IsUnique();

                    b.ToTable("UsersLastPolling");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(4010),
                            LastPolled = new DateTime(2021, 5, 15, 22, 14, 57, 587, DateTimeKind.Local).AddTicks(4507),
                            Passport = "1111222222"
                        });
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.Credit", b =>
                {
                    b.HasOne("DefenderUiGateway.Data.Model.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefenderUiGateway.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.CreditRequest", b =>
                {
                    b.HasOne("DefenderUiGateway.Data.Model.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefenderUiGateway.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefenderUiGateway.Data.Model.Push", b =>
                {
                    b.HasOne("DefenderUiGateway.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}