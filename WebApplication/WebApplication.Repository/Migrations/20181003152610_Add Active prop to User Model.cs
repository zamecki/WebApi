using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Repository.Migrations
{
    public partial class AddActiveproptoUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "TB_User",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "dbo",
                table: "TB_User");
        }
    }
}
