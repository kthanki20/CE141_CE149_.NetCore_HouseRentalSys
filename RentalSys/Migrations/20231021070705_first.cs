using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSys.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_HouseBooking_Tbl_HouseDetail_houseDetailsModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_HouseBooking_houseDetailsModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.DropColumn(
                name: "houseDetailsModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.AddColumn<int>(
                name: "HouseDetailModelHouseID",
                table: "Tbl_HouseBooking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_HouseBooking_HouseDetailModelHouseID",
                table: "Tbl_HouseBooking",
                column: "HouseDetailModelHouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_HouseBooking_Tbl_HouseDetail_HouseDetailModelHouseID",
                table: "Tbl_HouseBooking",
                column: "HouseDetailModelHouseID",
                principalTable: "Tbl_HouseDetail",
                principalColumn: "HouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_HouseBooking_Tbl_HouseDetail_HouseDetailModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_HouseBooking_HouseDetailModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.DropColumn(
                name: "HouseDetailModelHouseID",
                table: "Tbl_HouseBooking");

            migrationBuilder.AddColumn<int>(
                name: "houseDetailsModelHouseID",
                table: "Tbl_HouseBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_HouseBooking_houseDetailsModelHouseID",
                table: "Tbl_HouseBooking",
                column: "houseDetailsModelHouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_HouseBooking_Tbl_HouseDetail_houseDetailsModelHouseID",
                table: "Tbl_HouseBooking",
                column: "houseDetailsModelHouseID",
                principalTable: "Tbl_HouseDetail",
                principalColumn: "HouseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
