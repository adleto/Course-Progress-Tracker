using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourse.Database.Migrations
{
    public partial class cijenazaclanarinu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cijena",
                table: "TipUplate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "TipUplate");
        }
    }
}
