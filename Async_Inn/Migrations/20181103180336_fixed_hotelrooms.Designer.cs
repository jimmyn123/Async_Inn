﻿// <auto-generated />
using System;
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20181103180336_fixed_hotelrooms")]
    partial class fixed_hotelrooms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int?>("RoomID");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new { ID = 1, Name = "Coffee Machine" },
                        new { ID = 2, Name = "Pool" },
                        new { ID = 3, Name = "Gym" },
                        new { ID = 4, Name = "Ocean View" },
                        new { ID = 5, Name = "Spa" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new { ID = 1, Address = "1234 Rainier Ave, Seattle, WA, 98001", Name = "Async Inn - Seattle", Phone = "2061234567" },
                        new { ID = 2, Address = "2234 Rainier Ave, Lynnwood, WA, 98002", Name = "Async Inn - Lynnwood", Phone = "2062234567" },
                        new { ID = 3, Address = "3234 Rainier Ave, Bellevue, WA, 98003", Name = "Async Inn - Bellevue", Phone = "2063234567" },
                        new { ID = 4, Address = "4234 Rainier Ave, Redmond, WA, 98004", Name = "Async Inn - Redmond", Phone = "2064234567" },
                        new { ID = 5, Address = "5234 Rainier Ave, Kent, WA, 98005", Name = "Async Inn - Kent", Phone = "2065234567" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomNumber");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new { ID = 1, Layout = 1, Name = "Lover's Special" },
                        new { ID = 2, Layout = 2, Name = "Tropical Vacation" },
                        new { ID = 3, Layout = 0, Name = "Feels like Home" },
                        new { ID = 4, Layout = 2, Name = "Aquatic Package" },
                        new { ID = 5, Layout = 1, Name = "Out in Space" },
                        new { ID = 6, Layout = 2, Name = "Family Package" }
                    );
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn.Models.Amenities", b =>
                {
                    b.HasOne("Async_Inn.Models.Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.HasOne("Async_Inn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Async_Inn.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenities", b =>
                {
                    b.HasOne("Async_Inn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Async_Inn.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
