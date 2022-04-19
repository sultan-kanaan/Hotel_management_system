using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_management_system.Migrations
{
    public partial class updateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                column: "State",
                value: "jordan");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                column: "State",
                value: "jordan");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                column: "State",
                value: "jordan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3,
                column: "State",
                value: null);
        }
    }
}
