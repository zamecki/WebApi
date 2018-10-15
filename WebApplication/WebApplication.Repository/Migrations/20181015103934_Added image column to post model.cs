using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Repository.Migrations
{
    public partial class Addedimagecolumntopostmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageapiid",
                schema: "dbo",
                table: "TB_Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageapiid",
                schema: "dbo",
                table: "TB_Post");
        }
    }
}
