using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace collegemainatanceportal.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Complaints");
        }
    }
}
