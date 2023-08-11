﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using simpleproject.models;

#nullable disable

namespace simpleproject.Migrations
{
    [DbContext(typeof(datacontext))]
    partial class datacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("simpleproject.models.Category", b =>
                {
                    b.Property<long>("categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("categoryid"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryid");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("simpleproject.models.product", b =>
                {
                    b.Property<long>("productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("productid"));

                    b.Property<long>("categoryid")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("quality")
                        .HasColumnType("int");

                    b.Property<long>("supplierid")
                        .HasColumnType("bigint");

                    b.HasKey("productid");

                    b.HasIndex("categoryid");

                    b.HasIndex("supplierid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("simpleproject.models.review", b =>
                {
                    b.Property<int>("reviewid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewid"));

                    b.Property<string>("reviewrname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("reviewscore")
                        .HasColumnType("smallint");

                    b.HasKey("reviewid");

                    b.ToTable("review");
                });

            modelBuilder.Entity("simpleproject.models.supplier", b =>
                {
                    b.Property<long>("supplierid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("supplierid"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("supplierid");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("simpleproject.models.product", b =>
                {
                    b.HasOne("simpleproject.models.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("simpleproject.models.supplier", "supplier")
                        .WithMany("products")
                        .HasForeignKey("supplierid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("supplier");
                });

            modelBuilder.Entity("simpleproject.models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("simpleproject.models.supplier", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
