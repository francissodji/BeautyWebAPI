using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class StateMigr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDLenghtstyle",
                table: "Appointments",
                newName: "IDLenghtAppoint");

            migrationBuilder.AlterColumn<bool>(
                name: "HairProvStyle",
                table: "Styles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDLenghtAppoint",
                table: "Appointments",
                newName: "IDLenghtstyle");

            migrationBuilder.AlterColumn<bool>(
                name: "HairProvStyle",
                table: "Styles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
