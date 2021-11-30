﻿// <auto-generated />
using System;
using Labo.H05.RateAMovie.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labo.H05.RateAMovie.Web.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20211130181818_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<int>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.Property<int>("DirectorsId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("DirectorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("DirectorMovie");
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Keanu",
                            LastName = "Reeves"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Laurence",
                            LastName = "Fishburne"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Carrie-Anne",
                            LastName = "Moss"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Sean",
                            LastName = "Bean"
                        });
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "The Wachowski Brothers"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Newline Cinema"
                        });
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Lana",
                            LastName = "Wachowski"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Lilly",
                            LastName = "Wachowski"
                        });
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            Title = "The fellowship of the ring"
                        });
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieId = 1,
                            Review = "I think this movie is ok!",
                            Score = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            MovieId = 2,
                            Review = "I think this movie is superb!",
                            Score = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Jef",
                            Username = "jef"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Pol",
                            Username = "pol"
                        });
                });

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Movie", b =>
                {
                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Company", "Company")
                        .WithMany("Movies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Rating", b =>
                {
                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labo.H05.RateAMovie.Core.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Company", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.Movie", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Labo.H05.RateAMovie.Core.Entities.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
