using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace collegemainatanceportal.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HodStatus",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffStatus",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HodStatus",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "StaffStatus",
                table: "Complaints");
        }
    }
}