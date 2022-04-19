using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class Appointment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LnameClient",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CelClient",
                table: "Clients",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    IDAppoint = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAppoint = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddTakeOffAppoint = table.Column<bool>(type: "bit", nullable: false),
                    StateAppoint = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Typeservice = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NumberTrack = table.Column<int>(type: "int", nullable: false),
                    IDBraiderAppoint = table.Column<int>(type: "int", nullable: false),
                    IdBraiderOwner = table.Column<int>(type: "int", nullable: false),
                    IDClientAppoint = table.Column<int>(type: "int", nullable: false),
                    ClientIDClient = table.Column<int>(type: "int", nullable: true),
                    IDStyleAppoint = table.Column<int>(type: "int", nullable: false),
                    StyleIdStyle = table.Column<int>(type: "int", nullable: true),
                    IDLenghtstyle = table.Column<int>(type: "int", nullable: false),
                    LenghtIdExtrat = table.Column<int>(type: "int", nullable: true),
                    IdSizeAppoint = table.Column<int>(type: "int", nullable: false),
                    SizeIdSize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.IDAppoint);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientIDClient",
                        column: x => x.ClientIDClient,
                        principalTable: "Clients",
                        principalColumn: "IDClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Extrats_LenghtIdExtrat",
                        column: x => x.LenghtIdExtrat,
                        principalTable: "Extrats",
                        principalColumn: "IdExtrat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Sizes_SizeIdSize",
                        column: x => x.SizeIdSize,
                        principalTable: "Sizes",
                        principalColumn: "IdSize",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Styles_StyleIdStyle",
                        column: x => x.StyleIdStyle,
                        principalTable: "Styles",
                        principalColumn: "IdStyle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientIDClient",
                table: "Appointments",
                column: "ClientIDClient");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LenghtIdExtrat",
                table: "Appointments",
                column: "LenghtIdExtrat");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SizeIdSize",
                table: "Appointments",
                column: "SizeIdSize");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StyleIdStyle",
                table: "Appointments",
                column: "StyleIdStyle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "LnameClient",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
    }
}
