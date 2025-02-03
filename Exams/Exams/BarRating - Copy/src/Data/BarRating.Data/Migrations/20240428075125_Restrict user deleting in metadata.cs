using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarRating.Data.Migrations
{
    /// <inheritdoc />
    public partial class Restrictuserdeletinginmetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_AspNetUsers_CreatedById",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_AspNetUsers_CreatedById",
                table: "Bars",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_AspNetUsers_CreatedById",
                table: "Bars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_AspNetUsers_CreatedById",
                table: "Bars",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_CreatedById",
                table: "Reviews",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
