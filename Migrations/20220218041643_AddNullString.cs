using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class AddNullString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargeType",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "CostHairDeducted",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ModifyCostManu",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "TimeDoneStyle",
                table: "Styles");

            migrationBuilder.AlterColumn<string>(
                name: "PictureStyle",
                table: "Styles",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneClient",
                table: "Clients",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOBClient",
                table: "Clients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CelClient",
                table: "Clients",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PictureStyle",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargeType",
                table: "Styles",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CostHairDeducted",
                table: "Styles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "ModifyCostManu",
                table: "Styles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "TimeDoneStyle",
                table: "Styles",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneClient",
                table: "Clients",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOBClient",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CelClient",
                table: "Clients",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);
        }
    }
}
