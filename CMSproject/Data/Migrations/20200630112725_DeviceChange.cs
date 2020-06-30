using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSproject.Data.Migrations
{
    public partial class DeviceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Devices");
        }
    }
}
