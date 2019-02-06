﻿// <auto-generated />
using System;
using BetService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BetService.Migrations
{
    [DbContext(typeof(BetDbContext))]
    partial class BetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BetService.Models.Bet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BetCategoryId");

                    b.Property<long?>("EventId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Odd");

                    b.Property<decimal>("Percentage");

                    b.HasKey("Id");

                    b.HasIndex("BetCategoryId");

                    b.HasIndex("EventId");

                    b.ToTable("BetItems");
                });

            modelBuilder.Entity("BetService.Models.BetCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BetCategory");
                });

            modelBuilder.Entity("BetService.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BetService.Models.Bet", b =>
                {
                    b.HasOne("BetService.Models.BetCategory", "BetCategory")
                        .WithMany("Bets")
                        .HasForeignKey("BetCategoryId");

                    b.HasOne("BetService.Models.Event", "Event")
                        .WithMany("Bets")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
