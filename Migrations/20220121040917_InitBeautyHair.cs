using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class InitBeautyHair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    IdColor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleColor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    IDDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleDiscount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RateDiscount = table.Column<float>(type: "real", nullable: false),
                    CostDiscount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.IDDiscount);
                });

            migrationBuilder.CreateTable(
                name: "Extrats",
                columns: table => new
                {
                    IdExtrat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleExtrat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrats", x => x.IdExtrat);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    IdSize = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleSize = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.IdSize);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    IdStyle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesigStyle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HairProvStyle = table.Column<bool>(type: "bit", nullable: false),
                    CostStyle = table.Column<double>(type: "float", nullable: false),
                    PriceTakeOffHair = table.Column<double>(type: "float", nullable: false),
                    CostTouchUp = table.Column<double>(type: "float", nullable: false),
                    ChargeType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    TimeDoneStyle = table.Column<float>(type: "real", nullable: false),
                    ModifyCostManu = table.Column<bool>(type: "bit", nullable: false),
                    CostHairDeducted = table.Column<double>(type: "float", nullable: false),
                    PictureStyle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.IdStyle);
                });

            migrationBuilder.CreateTable(
                name: "Thewords",
                columns: table => new
                {
                    IDPassword = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NumConnection = table.Column<int>(type: "int", nullable: false),
                    DateBeginPw = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEndPw = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thewords", x => x.IDPassword);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dateuserexpire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Connectstate = table.Column<bool>(type: "bit", nullable: false),
                    IdProfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtratStyles",
                columns: table => new
                {
                    IdExtratStyle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStyle = table.Column<int>(type: "int", nullable: false),
                    IDExtrat = table.Column<int>(type: "int", nullable: false),
                    IdSize = table.Column<int>(type: "int", nullable: false),
                    CostExtra = table.Column<double>(type: "float", nullable: false),
                    CostTouchUpExtra = table.Column<double>(type: "float", nullable: false),
                    CostExtraSize = table.Column<double>(type: "float", nullable: false),
                    CostBusyExtra = table.Column<double>(type: "float", nullable: false),
                    CostHairDeductExtra = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtratStyles", x => x.IdExtratStyle);
                    table.ForeignKey(
                        name: "FK_ExtratStyles_Extrats_IdStyle",
                        column: x => x.IdStyle,
                        principalTable: "Extrats",
                        principalColumn: "IdExtrat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtratStyles_Sizes_IdSize",
                        column: x => x.IdSize,
                        principalTable: "Sizes",
                        principalColumn: "IdSize",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtratStyles_Styles_IdStyle",
                        column: x => x.IdStyle,
                        principalTable: "Styles",
                        principalColumn: "IdStyle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FnameClient = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MnameClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LnameClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneClient = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    SexClient = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DOBClient = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CelClient = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    StreetClient = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountyClient = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ZipCodeClient = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EmailClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateClient = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    UserIDUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IDClient);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserIDUser",
                        column: x => x.UserIDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserIDUser",
                table: "Clients",
                column: "UserIDUser");

            migrationBuilder.CreateIndex(
                name: "IX_ExtratStyles_IdSize",
                table: "ExtratStyles",
                column: "IdSize");

            migrationBuilder.CreateIndex(
                name: "IX_ExtratStyles_IdStyle",
                table: "ExtratStyles",
                column: "IdStyle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "ExtratStyles");

            migrationBuilder.DropTable(
                name: "Thewords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Extrats");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}
