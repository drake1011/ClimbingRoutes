﻿// <auto-generated />
using System;
using ClimbingRoutes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClimbingRoutes.Database.Migrations
{
    [DbContext(typeof(ClimbingRoutesContext))]
    [Migration("20191018185406_Update004")]
    partial class Update004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClimbingRoutes.Ascent", b =>
                {
                    b.Property<int>("AscentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AscentId");

                    b.HasIndex("RouteId");

                    b.HasIndex("StyleId");

                    b.HasIndex("UserId");

                    b.ToTable("Ascents");

                    b.HasData(
                        new
                        {
                            AscentId = 1,
                            Date = new DateTime(2015, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RouteId = 1,
                            StyleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            AscentId = 2,
                            Date = new DateTime(2011, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RouteId = 4,
                            StyleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            AscentId = 3,
                            Date = new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RouteId = 2,
                            StyleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            AscentId = 4,
                            Date = new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RouteId = 3,
                            StyleId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ClimbingRoutes.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            Description = "7a"
                        },
                        new
                        {
                            GradeId = 2,
                            Description = "7b"
                        },
                        new
                        {
                            GradeId = 3,
                            Description = "7c"
                        });
                });

            modelBuilder.Entity("ClimbingRoutes.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.HasIndex("GradeId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            RouteId = 1,
                            GradeId = 2,
                            Name = "Savage Amusement"
                        },
                        new
                        {
                            RouteId = 2,
                            GradeId = 1,
                            Name = "Nirvana"
                        },
                        new
                        {
                            RouteId = 4,
                            GradeId = 1,
                            Name = "Le Bon Vacance"
                        },
                        new
                        {
                            RouteId = 3,
                            GradeId = 3,
                            Name = "Sultan"
                        });
                });

            modelBuilder.Entity("ClimbingRoutes.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StyleId");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            StyleId = 1,
                            Description = "On Sight"
                        },
                        new
                        {
                            StyleId = 2,
                            Description = "Worked"
                        },
                        new
                        {
                            StyleId = 3,
                            Description = "Dogged"
                        },
                        new
                        {
                            StyleId = 4,
                            Description = "Fail"
                        });
                });

            modelBuilder.Entity("ClimbingRoutes.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "123@456.com",
                            Name = "Andy"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "789@456.com",
                            Name = "Keith"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "legend_of@456.com",
                            Name = "Zorro"
                        });
                });

            modelBuilder.Entity("ClimbingRoutes.Ascent", b =>
                {
                    b.HasOne("ClimbingRoutes.Route", null)
                        .WithMany("Ascents")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClimbingRoutes.Style", null)
                        .WithMany("Ascents")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClimbingRoutes.User", null)
                        .WithMany("Ascents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClimbingRoutes.Route", b =>
                {
                    b.HasOne("ClimbingRoutes.Grade", "Grade")
                        .WithMany("Routes")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
