using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourse.Database.Migrations
{
    public partial class prisustvoModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Prisustvovao",
                table: "IspitKlijentKursInstanca",
                nullable: false,
                defaultValue: false, //<-added
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Prisustvovao",
                table: "IspitKlijentKursInstanca",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
