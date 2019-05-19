using Microsoft.EntityFrameworkCore.Migrations;

namespace VolvoTrucks.Repository.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TruckModel",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "TruckModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
