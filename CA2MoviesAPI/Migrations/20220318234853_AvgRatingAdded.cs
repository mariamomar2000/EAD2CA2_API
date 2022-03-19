using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CA2MoviesAPI.Migrations
{
    public partial class AvgRatingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 23, 48, 53, 404, DateTimeKind.Local).AddTicks(3253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 18, 23, 18, 35, 122, DateTimeKind.Local).AddTicks(2920));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 23, 18, 35, 122, DateTimeKind.Local).AddTicks(2920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 18, 23, 48, 53, 404, DateTimeKind.Local).AddTicks(3253));
        }
    }
}
