using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBP.MyLittleBlog.Migrations
{
    public partial class added_commnet_with_like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "AppComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AppComments",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "AppComments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppComments");
        }
    }
}
