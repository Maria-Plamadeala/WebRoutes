﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRoutes.Data;

namespace WebRoutes.Migrations
{
    [DbContext(typeof(WebRoutesContext))]
    [Migration("20220109094611_ExtraOffer")]
    partial class ExtraOffer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebRoutes.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("extra_category_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ExtraCategory");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraOffer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("ExtraOffer");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraOfferCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("extracategoryID")
                        .HasColumnType("int");

                    b.Property<int>("extraofferID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("extracategoryID");

                    b.HasIndex("extraofferID");

                    b.ToTable("ExtraOfferCategory");
                });

            modelBuilder.Entity("WebRoutes.Models.Guide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Guide");
                });

            modelBuilder.Entity("WebRoutes.Models.Route", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("guideID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("ID");

                    b.HasIndex("guideID");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("WebRoutes.Models.RouteCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<int>("routeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.HasIndex("routeID");

                    b.ToTable("RouteCategory");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraOfferCategory", b =>
                {
                    b.HasOne("WebRoutes.Models.ExtraCategory", "ExtraCategory")
                        .WithMany("ExtraOfferCategories")
                        .HasForeignKey("extracategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRoutes.Models.ExtraOffer", "ExtraOffer")
                        .WithMany("ExtraOfferCategories")
                        .HasForeignKey("extraofferID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraCategory");

                    b.Navigation("ExtraOffer");
                });

            modelBuilder.Entity("WebRoutes.Models.Route", b =>
                {
                    b.HasOne("WebRoutes.Models.Guide", "Guide")
                        .WithMany("Routes")
                        .HasForeignKey("guideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("WebRoutes.Models.RouteCategory", b =>
                {
                    b.HasOne("WebRoutes.Models.Category", "Category")
                        .WithMany("RouteCategories")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRoutes.Models.Route", "Route")
                        .WithMany("RouteCategories")
                        .HasForeignKey("routeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("WebRoutes.Models.Category", b =>
                {
                    b.Navigation("RouteCategories");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraCategory", b =>
                {
                    b.Navigation("ExtraOfferCategories");
                });

            modelBuilder.Entity("WebRoutes.Models.ExtraOffer", b =>
                {
                    b.Navigation("ExtraOfferCategories");
                });

            modelBuilder.Entity("WebRoutes.Models.Guide", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("WebRoutes.Models.Route", b =>
                {
                    b.Navigation("RouteCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
