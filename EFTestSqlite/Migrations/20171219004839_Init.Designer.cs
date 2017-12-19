﻿// <auto-generated />
using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace EFTestSqlite.Migrations
{
    [DbContext(typeof(ValueDbContext))]
    [Migration("20171219004839_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Library.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Library.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Library.NoteCategory", b =>
                {
                    b.Property<int>("NoteId");

                    b.Property<int>("CategoryId");

                    b.HasKey("NoteId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Library.Value", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data");

                    b.Property<string>("TagCollection");

                    b.HasKey("Key");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Library.NoteCategory", b =>
                {
                    b.HasOne("Library.Category", "Category")
                        .WithMany("NoteCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Note", "Note")
                        .WithMany("NoteCategories")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}