﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using si730pc2u201624050.Infraestructure.Context;

#nullable disable

namespace si730pc2u201624050.Infraestructure.Migrations
{
    [DbContext(typeof(TravelersDbContext))]
    partial class TravelersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("si730pc2u201624050.Infraestructure.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IsRisky")
                        .HasColumnType("int");

                    b.Property<int>("MaxUsers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });
#pragma warning restore 612, 618
        }
    }
}
