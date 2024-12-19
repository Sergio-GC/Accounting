﻿// <auto-generated />
using System;
using Accounting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accounting.Migrations
{
    [DbContext(typeof(AccountingContext))]
    [Migration("20241219101600_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Accounting.Entities.CalendarEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("CalendarEntries");
                });

            modelBuilder.Entity("Accounting.Entities.Kid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("CalendarEntryKid", b =>
                {
                    b.Property<int>("CalendarEntriesId")
                        .HasColumnType("int");

                    b.Property<int>("KidsId")
                        .HasColumnType("int");

                    b.HasKey("CalendarEntriesId", "KidsId");

                    b.HasIndex("KidsId");

                    b.ToTable("CalendarEntryKids", (string)null);
                });

            modelBuilder.Entity("KidKid", b =>
                {
                    b.Property<int>("SiblingOfId")
                        .HasColumnType("int");

                    b.Property<int>("SiblingsId")
                        .HasColumnType("int");

                    b.HasKey("SiblingOfId", "SiblingsId");

                    b.HasIndex("SiblingsId");

                    b.ToTable("KidSiblings", (string)null);
                });

            modelBuilder.Entity("CalendarEntryKid", b =>
                {
                    b.HasOne("Accounting.Entities.CalendarEntry", null)
                        .WithMany()
                        .HasForeignKey("CalendarEntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounting.Entities.Kid", null)
                        .WithMany()
                        .HasForeignKey("KidsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KidKid", b =>
                {
                    b.HasOne("Accounting.Entities.Kid", null)
                        .WithMany()
                        .HasForeignKey("SiblingOfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounting.Entities.Kid", null)
                        .WithMany()
                        .HasForeignKey("SiblingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
