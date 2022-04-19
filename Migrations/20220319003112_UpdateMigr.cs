using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class UpdateMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_ClientIDClient",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Extrats_LenghtIdExtrat",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Sizes_SizeIdSize",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Styles_StyleIdStyle",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "StyleIdStyle",
                table: "Appointments",
                newName: "styleIdStyle");

            migrationBuilder.RenameColumn(
                name: "SizeIdSize",
                table: "Appointments",
                newName: "sizeIdSize");

            migrationBuilder.RenameColumn(
                name: "ClientIDClient",
                table: "Appointments",
                newName: "clientIDClient");

            migrationBuilder.RenameColumn(
                name: "LenghtIdExtrat",
                table: "Appointments",
                newName: "lengthIdExtrat");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_StyleIdStyle",
                table: "Appointments",
                newName: "IX_Appointments_styleIdStyle");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SizeIdSize",
                table: "Appointments",
                newName: "IX_Appointments_sizeIdSize");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ClientIDClient",
                table: "Appointments",
                newName: "IX_Appointments_clientIDClient");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_LenghtIdExtrat",
                table: "Appointments",
                newName: "IX_Appointments_lengthIdExtrat");

            migrationBuilder.CreateTable(
                name: "HistoryAppointJobs",
                columns: table => new
                {
                    IdJHistoryAppointJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDAppoint = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdStyle = table.Column<int>(type: "int", nullable: true),
                    IdSize = table.Column<int>(type: "int", nullable: true),
                    IdLenght = table.Column<int>(type: "int", nullable: true),
                    StateJobHistory = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DateJobHistory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddTakeOffAppoint = table.Column<bool>(type: "bit", nullable: true),
                    Typeservice = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    NumberTrack = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryAppointJobs", x => x.IdJHistoryAppointJob);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_clientIDClient",
                table: "Appointments",
                column: "clientIDClient",
                principalTable: "Clients",
                principalColumn: "IDClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Extrats_lengthIdExtrat",
                table: "Appointments",
                column: "lengthIdExtrat",
                principalTable: "Extrats",
                principalColumn: "IdExtrat",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Sizes_sizeIdSize",
                table: "Appointments",
                column: "sizeIdSize",
                principalTable: "Sizes",
                principalColumn: "IdSize",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Styles_styleIdStyle",
                table: "Appointments",
                column: "styleIdStyle",
                principalTable: "Styles",
                principalColumn: "IdStyle",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_clientIDClient",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Extrats_lengthIdExtrat",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Sizes_sizeIdSize",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Styles_styleIdStyle",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "HistoryAppointJobs");

            migrationBuilder.RenameColumn(
                name: "styleIdStyle",
                table: "Appointments",
                newName: "StyleIdStyle");

            migrationBuilder.RenameColumn(
                name: "sizeIdSize",
                table: "Appointments",
                newName: "SizeIdSize");

            migrationBuilder.RenameColumn(
                name: "clientIDClient",
                table: "Appointments",
                newName: "ClientIDClient");

            migrationBuilder.RenameColumn(
                name: "lengthIdExtrat",
                table: "Appointments",
                newName: "LenghtIdExtrat");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_styleIdStyle",
                table: "Appointments",
                newName: "IX_Appointments_StyleIdStyle");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_sizeIdSize",
                table: "Appointments",
                newName: "IX_Appointments_SizeIdSize");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_clientIDClient",
                table: "Appointments",
                newName: "IX_Appointments_ClientIDClient");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_lengthIdExtrat",
                table: "Appointments",
                newName: "IX_Appointments_LenghtIdExtrat");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_ClientIDClient",
                table: "Appointments",
                column: "ClientIDClient",
                principalTable: "Clients",
                principalColumn: "IDClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Extrats_LenghtIdExtrat",
                table: "Appointments",
                column: "LenghtIdExtrat",
                principalTable: "Extrats",
                principalColumn: "IdExtrat",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Sizes_SizeIdSize",
                table: "Appointments",
                column: "SizeIdSize",
                principalTable: "Sizes",
                principalColumn: "IdSize",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Styles_StyleIdStyle",
                table: "Appointments",
                column: "StyleIdStyle",
                principalTable: "Styles",
                principalColumn: "IdStyle",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
