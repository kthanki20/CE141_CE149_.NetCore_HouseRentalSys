using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSys.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_HouseDetail",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseRentAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_HouseDetail", x => x.HouseID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_HouseBooking",
                columns: table => new
                {
                    Bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bCusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bCusAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bCusEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bCusPhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bCusCnic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    houseDetailsModelHouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_HouseBooking", x => x.Bid);
                    table.ForeignKey(
                        name: "FK_Tbl_HouseBooking_Tbl_HouseDetail_houseDetailsModelHouseID",
                        column: x => x.houseDetailsModelHouseID,
                        principalTable: "Tbl_HouseDetail",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_HouseBooking_houseDetailsModelHouseID",
                table: "Tbl_HouseBooking",
                column: "houseDetailsModelHouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Admin");

            migrationBuilder.DropTable(
                name: "Tbl_HouseBooking");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_HouseDetail");
        }
    }
}
