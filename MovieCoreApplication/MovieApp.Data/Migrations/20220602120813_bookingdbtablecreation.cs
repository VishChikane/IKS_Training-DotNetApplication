using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Data.Migrations
{
    public partial class bookingdbtablecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "bookingModel",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingModel", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookingModel_movieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movieModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModel_theatreModel_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatreModel",
                        principalColumn: "ThreatreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingModel_userModel_UserId",
                        column: x => x.UserId,
                        principalTable: "userModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_MovieId",
                table: "bookingModel",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_TheatreId",
                table: "bookingModel",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingModel_UserId",
                table: "bookingModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingModel");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
