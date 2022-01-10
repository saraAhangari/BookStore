﻿// <auto-generated />
using BookStore.Server.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Server.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20220110082044_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Shared.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int>("publisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.HasIndex("publisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "nothing",
                            Title = "power",
                            categoryId = 2,
                            publisherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "nothing",
                            Title = "I,Tonya",
                            categoryId = 3,
                            publisherId = 1
                        });
                });

            modelBuilder.Entity("BookStore.Shared.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Biology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("BookStore.Shared.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New World"
                        });
                });

            modelBuilder.Entity("BookStore.Shared.Model.Book", b =>
                {
                    b.HasOne("BookStore.Shared.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Shared.Model.Publisher", "publisher")
                        .WithMany("book")
                        .HasForeignKey("publisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("publisher");
                });

            modelBuilder.Entity("BookStore.Shared.Model.Publisher", b =>
                {
                    b.Navigation("book");
                });
#pragma warning restore 612, 618
        }
    }
}
