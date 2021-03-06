// <auto-generated />
using Hotel_management_system.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hotel_management_system.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20220419004558_updateHotelsTable")]
    partial class updateHotelsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel_management_system.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "air conditioning"
                        },
                        new
                        {
                            ID = 2,
                            Name = "coffee maker"
                        },
                        new
                        {
                            ID = 3,
                            Name = "ocean view"
                        },
                        new
                        {
                            ID = 4,
                            Name = "mini bar"
                        });
                });

            modelBuilder.Entity("Hotel_management_system.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Amman",
                            Name = "Async Inn-Amman",
                            Phone = "00962675355"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Aqapa",
                            Name = "Async Inn-Aqapa",
                            Phone = "00962675353"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Deadsee",
                            Name = "Async Inn-Deadsee",
                            Phone = "00962675351"
                        });
                });

            modelBuilder.Entity("Hotel_management_system.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Hotel_management_system.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "cozy studio"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "one bedroom"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "2 bedrooms"
                        });
                });

            modelBuilder.Entity("Hotel_management_system.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Hotel_management_system.Models.HotelRoom", b =>
                {
                    b.HasOne("Hotel_management_system.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel_management_system.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel_management_system.Models.RoomAmenities", b =>
                {
                    b.HasOne("Hotel_management_system.Models.Amenity", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel_management_system.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenities");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel_management_system.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("Hotel_management_system.Models.Hotel", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Hotel_management_system.Models.Room", b =>
                {
                    b.Navigation("HotelRoom");

                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
