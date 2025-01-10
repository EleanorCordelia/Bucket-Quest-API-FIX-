using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BucketQuestAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Bookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactName = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    Participants = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    BookerId = table.Column<int>(type: "integer", nullable: true),
                    TripPackageId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Accounts_BookerId",
                        column: x => x.BookerId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_TripPackages_TripPackageId",
                        column: x => x.TripPackageId,
                        principalTable: "TripPackages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookerId",
                table: "Bookings",
                column: "BookerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TripPackageId",
                table: "Bookings",
                column: "TripPackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
