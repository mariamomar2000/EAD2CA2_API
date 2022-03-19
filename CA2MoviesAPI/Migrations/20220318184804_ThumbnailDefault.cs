using Microsoft.EntityFrameworkCore.Migrations;

namespace CA2MoviesAPI.Migrations
{
    public partial class ThumbnailDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "default.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default.png");
        }
    }
}
