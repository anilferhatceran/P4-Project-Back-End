﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebsiteServices.Models;

namespace WebsiteServices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210622081027_initialcreation")]
    partial class initialcreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebsiteServices.Models.CompanyProfile", b =>
                {
                    b.Property<int>("companyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyID");

                    b.ToTable("CompanyProfiles");
                });

            modelBuilder.Entity("WebsiteServices.Models.NameGenUser", b =>
                {
                    b.Property<int>("nameGenUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("nameGenID")
                        .HasColumnType("int");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("nameGenUserID");

                    b.HasIndex("nameGenID");

                    b.HasIndex("userID");

                    b.ToTable("NameGenUsers");
                });

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

            modelBuilder.Entity("WebsiteServices.Models.ReviewDetail", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("companyID")
                        .HasColumnType("int");

                    b.Property<string>("reviewDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reviewRating")
                        .HasColumnType("int");

                    b.Property<string>("reviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reviewTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("reviewID");

                    b.HasIndex("companyID");

                    b.HasIndex("userID");

                    b.ToTable("ReviewDetails");
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

            modelBuilder.Entity("WebsiteServices.Models.NameGenUser", b =>
                {
                    b.HasOne("WebsiteServices.Models.NameGenerated", "name")
                        .WithMany()
                        .HasForeignKey("nameGenID");

                    b.HasOne("WebsiteServices.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("WebsiteServices.Models.ReviewDetail", b =>
                {
                    b.HasOne("WebsiteServices.Models.CompanyProfile", "company")
                        .WithMany()
                        .HasForeignKey("companyID");

                    b.HasOne("WebsiteServices.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userID");
                });
#pragma warning restore 612, 618
        }
    }
}
