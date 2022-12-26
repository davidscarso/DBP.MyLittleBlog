using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBP.MyLittleBlog.Migrations
{
    public partial class created_entityB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModuleBEntityBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value1 = table.Column<int>(type: "int", nullable: false),
                    Value2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleBEntityBs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleBEntityBs");
        }
    }
}
