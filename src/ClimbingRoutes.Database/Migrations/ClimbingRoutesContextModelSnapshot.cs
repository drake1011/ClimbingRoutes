﻿// <auto-generated />
using System;
using ClimbingRoutes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClimbingRoutes.Database.Migrations
{
    [DbContext(typeof(ClimbingRoutesContext))]
    partial class ClimbingRoutesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClimbingRoutes.Ascent", b =>
                {
                    b.Property<int>("AscentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("RouteId");

                    b.Property<int>("StyleId");

                    b.Property<int>("UserId");

                    b.HasKey("AscentId");

                    b.HasIndex("RouteId");

                    b.HasIndex("StyleId");

                    b.HasIndex("UserId");

                    b.ToTable("Ascents");
                });

            modelBuilder.Entity("ClimbingRoutes.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ClimbingRoutes.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId");

                    b.Property<string>("Name");

                    b.HasKey("RouteId");

                    b.HasIndex("GradeId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("ClimbingRoutes.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("StyleId");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("ClimbingRoutes.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClimbingRoutes.Ascent", b =>
                {
                    b.HasOne("ClimbingRoutes.Route")
                        .WithMany("Ascents")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClimbingRoutes.Style")
                        .WithMany("Ascents")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClimbingRoutes.User")
                        .WithMany("Ascents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClimbingRoutes.Route", b =>
                {
                    b.HasOne("ClimbingRoutes.Grade", "Grade")
                        .WithMany("Routes")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
