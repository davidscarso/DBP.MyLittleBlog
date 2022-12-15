using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBP.MyLittleBlog.Migrations
{
    public partial class added_States_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClosedReason",
                table: "AppBlogPosts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "AppBlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AppBlogPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedReason",
                table: "AppBlogPosts");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "AppBlogPosts");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AppBlogPosts");
        }
    }
}
