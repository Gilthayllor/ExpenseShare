﻿// <auto-generated />
using System;
using ExpenseShare.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseShare.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseShare.Domain.Expenses.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("ExpenseShare.Domain.Expenses.ExpenseParticipant", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ExpenseId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("ExpenseParticipants", (string)null);
                });

            modelBuilder.Entity("ExpenseShare.Domain.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("ExpenseShare.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2dfc78fb-1674-42b0-9fed-a2ca496a6e79"),
                            Email = "gilthayllor@outlook.com"
                        },
                        new
                        {
                            Id = new Guid("34a24c2b-d3e8-41a1-b3ed-b9a5e59aae47"),
                            Email = "saralimabrandao@outlook.com"
                        });
                });

            modelBuilder.Entity("ExpenseShare.Domain.Expenses.Expense", b =>
                {
                    b.HasOne("ExpenseShare.Domain.Rooms.Room", "Room")
                        .WithMany("Expenses")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ExpenseShare.Domain.Expenses.Money", "ExpenseValue", b1 =>
                        {
                            b1.Property<Guid>("ExpenseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ExpenseAmount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ExpenseCurrency");

                            b1.HasKey("ExpenseId");

                            b1.ToTable("Expenses");

                            b1.WithOwner()
                                .HasForeignKey("ExpenseId");
                        });

                    b.Navigation("ExpenseValue")
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ExpenseShare.Domain.Expenses.ExpenseParticipant", b =>
                {
                    b.HasOne("ExpenseShare.Domain.Expenses.Expense", null)
                        .WithMany("ExpenseParticipants")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ExpenseShare.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("ExpenseShare.Domain.Expenses.Money", "AmountOwed", b1 =>
                        {
                            b1.Property<Guid>("ExpenseParticipantUserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ExpenseParticipantExpenseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("AmountOwed");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AmountOwedCurrency");

                            b1.HasKey("ExpenseParticipantUserId", "ExpenseParticipantExpenseId");

                            b1.ToTable("ExpenseParticipants");

                            b1.WithOwner()
                                .HasForeignKey("ExpenseParticipantUserId", "ExpenseParticipantExpenseId");
                        });

                    b.OwnsOne("ExpenseShare.Domain.Expenses.Money", "AmountPaid", b1 =>
                        {
                            b1.Property<Guid>("ExpenseParticipantUserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ExpenseParticipantExpenseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("AmountPaid");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AmountPaidCurrency");

                            b1.HasKey("ExpenseParticipantUserId", "ExpenseParticipantExpenseId");

                            b1.ToTable("ExpenseParticipants");

                            b1.WithOwner()
                                .HasForeignKey("ExpenseParticipantUserId", "ExpenseParticipantExpenseId");
                        });

                    b.Navigation("AmountOwed")
                        .IsRequired();

                    b.Navigation("AmountPaid")
                        .IsRequired();
                });

            modelBuilder.Entity("ExpenseShare.Domain.Users.User", b =>
                {
                    b.HasOne("ExpenseShare.Domain.Rooms.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("ExpenseShare.Domain.Users.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = new Guid("2dfc78fb-1674-42b0-9fed-a2ca496a6e79"),
                                    FirstName = "Gilthayllor",
                                    LastName = "Sousa"
                                },
                                new
                                {
                                    UserId = new Guid("34a24c2b-d3e8-41a1-b3ed-b9a5e59aae47"),
                                    FirstName = "Sara",
                                    LastName = "Brandão"
                                });
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ExpenseShare.Domain.Expenses.Expense", b =>
                {
                    b.Navigation("ExpenseParticipants");
                });

            modelBuilder.Entity("ExpenseShare.Domain.Rooms.Room", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
