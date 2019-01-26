﻿// <auto-generated />
using System;
using Crawler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crawler.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190126194313_Alter-UriBetToParse-AddColumn-Name")]
    partial class AlterUriBetToParseAddColumnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crawler.Models.Entity.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Odd");

                    b.Property<decimal>("Percentage");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Crawler.Models.Entity.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BetType");

                    b.Property<string>("CompetitionName");

                    b.Property<string>("Name");

                    b.Property<string>("Sport");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Crawler.Models.Entity.UriBetsToParse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("UrisBetsToParse");
                });

            modelBuilder.Entity("Crawler.Models.Entity.Bet", b =>
                {
                    b.HasOne("Crawler.Models.Entity.Event")
                        .WithMany("BetAvailables")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}