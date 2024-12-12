﻿// <auto-generated />
using System;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApi.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20241212193127_InitialSeeding")]
    partial class InitialSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("LibraryApi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "George Orwell"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Harper Lee"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aldous Huxley"
                        },
                        new
                        {
                            Id = 4,
                            Name = "J.K. Rowling"
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Title = "1984",
                            Year = 1949
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Title = "Animal Farm",
                            Year = 1945
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Title = "To Kill a Mockingbird",
                            Year = 1960
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            Title = "Brave New World",
                            Year = 1932
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            Title = "Harry Potter and the Philosopher's Stone",
                            Year = 1997
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            LoanDate = new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            LoanDate = new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReturnDate = new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 4,
                            LoanDate = new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LibraryApi.Models.Book", b =>
                {
                    b.HasOne("LibraryApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LibraryApi.Models.Loan", b =>
                {
                    b.HasOne("LibraryApi.Models.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApi.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryApi.Models.Book", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}