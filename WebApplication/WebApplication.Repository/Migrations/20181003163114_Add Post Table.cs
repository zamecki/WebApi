using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Repository.Migrations
{
    public partial class AddPostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                schema: "dbo",
                table: "TB_User",
                newName: "active");

            migrationBuilder.AlterColumn<bool>(
                name: "active",
                schema: "dbo",
                table: "TB_User",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "TB_Post",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    createtime = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    message = table.Column<string>(maxLength: 256, nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Post_TB_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "TB_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Post_UserID",
                schema: "dbo",
                table: "TB_Post",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Post",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "active",
                schema: "dbo",
                table: "TB_User",
                newName: "Active");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "TB_User",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
