﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MusArticle.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230105154407_secondm")]
    partial class secondm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociatedMuseumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedMuseumId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            AssociatedMuseumId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "David Statue",
                            State = "OK"
                        });
                });

            modelBuilder.Entity("Entities.Models.Museum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MuseumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Theme")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Museums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Bellas Artes",
                            Theme = 0
                        });
                });

            modelBuilder.Entity("Entities.Models.Article", b =>
                {
                    b.HasOne("Entities.Models.Museum", "Museum")
                        .WithMany("Articles")
                        .HasForeignKey("AssociatedMuseumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}