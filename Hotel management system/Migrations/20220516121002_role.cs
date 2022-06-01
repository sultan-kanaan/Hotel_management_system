using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_management_system.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "district manager", "00000000-0000-0000-0000-000000000000", "District Manager", "DISTRICT MANAGER" },
                    { "propertymanager", "00000000-0000-0000-0000-000000000000", "PropertyManager", "PROPERTYMANAGER" },
                    { "agent", "00000000-0000-0000-0000-000000000000", "Agent", "AGENT" },
                    { "anonymous", "00000000-0000-0000-0000-000000000000", "Anonymous", "ANONYMOUS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "Create Hotel", "district manager" },
                    { 24, "permissions", "See Hotels", "propertymanager" },
                    { 25, "permissions", "Create HotelRoom", "propertymanager" },
                    { 26, "permissions", "See HotelRooms", "propertymanager" },
                    { 27, "permissions", "Update HotelRooms", "propertymanager" },
                    { 28, "permissions", "See Rooms", "propertymanager" },
                    { 29, "permissions", "See Amenities", "propertymanager" },
                    { 30, "permissions", "Add Amenity to Room", "propertymanager" },
                    { 31, "permissions", "Delete Amenity From Room", "propertymanager" },
                    { 32, "permissions", "Update Amenity", "propertymanager" },
                    { 33, "permissions", "Add Room to Hotel", "propertymanager" },
                    { 34, "permissions", "See HotelRooms", "agent" },
                    { 35, "permissions", "Update HotelRooms", "agent" },
                    { 36, "permissions", "See Amenities", "agent" },
                    { 37, "permissions", "Add Amenity to Room", "agent" },
                    { 38, "permissions", "Delete Amenity From Room", "agent" },
                    { 39, "permissions", "See Hotels", "anonymous" },
                    { 40, "permissions", "See HotelRooms", "anonymous" },
                    { 23, "permissions", "Add Room to Hotel", "district manager" },
                    { 22, "permissions", "Create account for Anonymous User", "district manager" },
                    { 21, "permissions", "Create Account for Property Manager", "district manager" },
                    { 20, "permissions", "Create Account for Agent", "district manager" },
                    { 2, "permissions", "See Hotels", "district manager" },
                    { 3, "permissions", "Update Hotel", "district manager" },
                    { 4, "permissions", "Delete Hotel", "district manager" },
                    { 5, "permissions", "Create HotelRoom", "district manager" },
                    { 6, "permissions", "See HotelRooms", "district manager" },
                    { 7, "permissions", "Update HotelRooms", "district manager" },
                    { 8, "permissions", "Delete HotelRooms", "district manager" },
                    { 9, "permissions", "Create Rooms", "district manager" },
                    { 41, "permissions", "See Rooms", "anonymous" },
                    { 10, "permissions", "See Rooms", "district manager" },
                    { 12, "permissions", "Delete Rooms", "district manager" },
                    { 13, "permissions", "Create Amenity", "district manager" },
                    { 14, "permissions", "See Amenities", "district manager" },
                    { 15, "permissions", "Add Amenity to Room", "district manager" },
                    { 16, "permissions", "Delete Amenity From Room", "district manager" },
                    { 17, "permissions", "Update Amenity", "district manager" },
                    { 18, "permissions", "Delete Amenity", "district manager" },
                    { 19, "permissions", "Create Account for District Manager", "district manager" },
                    { 11, "permissions", "Update Rooms", "district manager" },
                    { 42, "permissions", "See Amenities", "anonymous" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "agent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "anonymous");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "district manager");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "propertymanager");
        }
    }
}
