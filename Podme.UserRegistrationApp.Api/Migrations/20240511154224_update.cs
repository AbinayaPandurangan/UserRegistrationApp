using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Podme.UserRegistrationApp.Api.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "UserInformations");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "UserInformations",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "UserInformations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "UserInformations");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNo",
                table: "UserInformations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "UserInformations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
