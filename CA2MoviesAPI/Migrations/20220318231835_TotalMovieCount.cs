using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CA2MoviesAPI.Migrations
{
    public partial class TotalMovieCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 23, 18, 35, 122, DateTimeKind.Local).AddTicks(2920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 18, 19, 9, 2, 697, DateTimeKind.Local).AddTicks(3522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Movies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 19, 9, 2, 697, DateTimeKind.Local).AddTicks(3522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 18, 23, 18, 35, 122, DateTimeKind.Local).AddTicks(2920));
        }
    }
}
