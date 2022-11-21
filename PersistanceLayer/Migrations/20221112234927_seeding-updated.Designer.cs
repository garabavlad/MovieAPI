﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPI.Persistance;

#nullable disable

namespace PersistanceLayer.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    [Migration("20221112234927_seeding-updated")]
    partial class seedingupdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieAPI.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Movie1"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Movie2"
                        },
                        new
                        {
                            Id = 3L,
                            Title = "Movie3"
                        },
                        new
                        {
                            Id = 4L,
                            Title = "Movie4"
                        },
                        new
                        {
                            Id = 5L,
                            Title = "Movie5"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.MovieGenre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ParentGenreId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentMovieId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentGenreId")
                        .IsUnique();

                    b.HasIndex("ParentMovieId");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ParentGenreId = 1L,
                            ParentMovieId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ParentGenreId = 2L,
                            ParentMovieId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            ParentGenreId = 5L,
                            ParentMovieId = 2L
                        },
                        new
                        {
                            Id = 4L,
                            ParentGenreId = 4L,
                            ParentMovieId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            ParentGenreId = 3L,
                            ParentMovieId = 3L
                        },
                        new
                        {
                            Id = 6L,
                            ParentGenreId = 4L,
                            ParentMovieId = 3L
                        },
                        new
                        {
                            Id = 7L,
                            ParentGenreId = 2L,
                            ParentMovieId = 4L
                        },
                        new
                        {
                            Id = 8L,
                            ParentGenreId = 1L,
                            ParentMovieId = 5L
                        },
                        new
                        {
                            Id = 9L,
                            ParentGenreId = 4L,
                            ParentMovieId = 5L
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ParentMovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentUserId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ParentMovieId");

                    b.HasIndex("ParentUserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ParentMovieId = 1L,
                            ParentUserId = 1L,
                            Rating = 4m
                        },
                        new
                        {
                            Id = 2L,
                            ParentMovieId = 2L,
                            ParentUserId = 1L,
                            Rating = 3m
                        },
                        new
                        {
                            Id = 3L,
                            ParentMovieId = 3L,
                            ParentUserId = 1L,
                            Rating = 2m
                        },
                        new
                        {
                            Id = 4L,
                            ParentMovieId = 5L,
                            ParentUserId = 1L,
                            Rating = 3m
                        },
                        new
                        {
                            Id = 5L,
                            ParentMovieId = 1L,
                            ParentUserId = 2L,
                            Rating = 5m
                        },
                        new
                        {
                            Id = 6L,
                            ParentMovieId = 2L,
                            ParentUserId = 2L,
                            Rating = 4m
                        },
                        new
                        {
                            Id = 7L,
                            ParentMovieId = 3L,
                            ParentUserId = 2L,
                            Rating = 1m
                        },
                        new
                        {
                            Id = 8L,
                            ParentMovieId = 4L,
                            ParentUserId = 2L,
                            Rating = 2m
                        },
                        new
                        {
                            Id = 9L,
                            ParentMovieId = 5L,
                            ParentUserId = 2L,
                            Rating = 4m
                        },
                        new
                        {
                            Id = 11L,
                            ParentMovieId = 1L,
                            ParentUserId = 3L,
                            Rating = 4m
                        },
                        new
                        {
                            Id = 15L,
                            ParentMovieId = 3L,
                            ParentUserId = 3L,
                            Rating = 4m
                        },
                        new
                        {
                            Id = 16L,
                            ParentMovieId = 4L,
                            ParentUserId = 3L,
                            Rating = 3m
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Username = "Vlad"
                        },
                        new
                        {
                            Id = 2L,
                            Username = "John"
                        },
                        new
                        {
                            Id = 3L,
                            Username = "Alison"
                        });
                });

            modelBuilder.Entity("MovieAPI.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieAPI.Models.Genre", "Genre")
                        .WithOne("MovieGenre")
                        .HasForeignKey("MovieAPI.Models.MovieGenre", "ParentGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.Movie", "Movie")
                        .WithMany("GenreMovie")
                        .HasForeignKey("ParentMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieAPI.Models.Review", b =>
                {
                    b.HasOne("MovieAPI.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("ParentMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPI.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("ParentUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieAPI.Models.Genre", b =>
                {
                    b.Navigation("MovieGenre")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieAPI.Models.Movie", b =>
                {
                    b.Navigation("GenreMovie");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MovieAPI.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
