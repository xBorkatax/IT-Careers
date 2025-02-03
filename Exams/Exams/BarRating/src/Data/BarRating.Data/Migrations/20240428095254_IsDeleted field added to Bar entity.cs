using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarRating.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedfieldaddedtoBarentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Bars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Bars");
        }
    }
}
