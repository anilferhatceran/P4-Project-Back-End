﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebsiteServices.Models;

namespace WebsiteServices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210603094358_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebsiteServices.Models.NameGenerated", b =>
                {
                    b.Property<int>("nameGenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("femaleNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maleNames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nameGenID");

                    b.ToTable("NamesGenerated");
                });

            modelBuilder.Entity("WebsiteServices.Models.TextGenerator", b =>
                {
                    b.Property<int>("wordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("wordID");

                    b.ToTable("TextsGenerated");
                });

            modelBuilder.Entity("WebsiteServices.Models.TypingSession", b =>
                {
                    b.Property<int>("sessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("charactersTyped")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("wordsPerMin")
                        .HasColumnType("int");

                    b.HasKey("sessionID");

                    b.ToTable("TypingSessions");
                });

            modelBuilder.Entity("WebsiteServices.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}