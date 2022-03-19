using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CA2MoviesAPI.Migrations
{
    public partial class CommentDate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 18, 19, 9, 2, 697, DateTimeKind.Local).AddTicks(3522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 18, 19, 9, 2, 697, DateTimeKind.Local).AddTicks(3522));
        }
    }
}
