using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyWebAPI.Migrations
{
    public partial class AddLibraryUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_clientIDClient",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserIDUser",
                table: "Clients");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IDUser",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "UserIDUser",
                table: "Clients",
                newName: "UserIdUser");

            migrationBuilder.RenameColumn(
                name: "IDUser",
                table: "Clients",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "IDClient",
                table: "Clients",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserIDUser",
                table: "Clients",
                newName: "IX_Clients_UserIdUser");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAddedAccount = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdAccount);
                });

            migrationBuilder.CreateTable(
                name: "Associates",
                columns: table => new
                {
                    IdAssociate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FnameAssociate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MnameAssociate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LnameAssociate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOBAssociate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    PhoneAssociate = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    CelAssociate = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    EmailAssociate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerStatus = table.Column<bool>(type: "bit", nullable: true),
                    IsAssociateUseRegister = table.Column<bool>(type: "bit", nullable: true),
                    IdRegisterAssociate = table.Column<bool>(type: "bit", nullable: true),
                    StreetAssociate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountyAssociate = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ZipCodeAssociate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    StateAssociate = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DisplayAccontHeaderA = table.Column<bool>(type: "bit", nullable: true),
                    IdUserAssociate = table.Column<int>(type: "int", nullable: true),
                    UserIdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associates", x => x.IdAssociate);
                    table.ForeignKey(
                        name: "FK_Associates_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdComp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcronymComp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DesignationComp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneOffice = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    PhoneOwner = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    IdOwnerBraider = table.Column<int>(type: "int", nullable: true),
                    PartPayeBraid = table.Column<float>(type: "real", nullable: true),
                    CostHairDeduct = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CostTakeDown = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    IdMainRegister = table.Column<int>(type: "int", nullable: true),
                    StateTaxOnSale = table.Column<float>(type: "real", nullable: true),
                    StateTaxOnBraiding = table.Column<float>(type: "real", nullable: true),
                    StreetComp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountyComp = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ZipcodeComp = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    StateComp = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    EmailComp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebsiteComp = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SubDomaine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateWorkMond = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkTues = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkWed = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkThur = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkFrid = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkSatu = table.Column<bool>(type: "bit", nullable: true),
                    DateWorkSund = table.Column<bool>(type: "bit", nullable: true),
                    TimeWorkBegin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeWorkEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptPartialPay = table.Column<bool>(type: "bit", nullable: true),
                    PercentPayPartialPay = table.Column<float>(type: "real", nullable: true),
                    AmountPayPartialPay = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MaxBraider = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdComp);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dateuserexpire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Connectstate = table.Column<bool>(type: "bit", nullable: true),
                    IdProfil = table.Column<int>(type: "int", nullable: false),
                    TokenUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    IdSuscript = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    TypeSuscript = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateBeginSouscrip = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEndSouscrip = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodSouscrip = table.Column<int>(type: "int", nullable: false),
                    AccountIdAccount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.IdSuscript);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Accounts_AccountIdAccount",
                        column: x => x.AccountIdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesAccounts",
                columns: table => new
                {
                    IdAccountAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false),
                    StateUsed = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesAccounts", x => x.IdAccountAccount);
                    table.ForeignKey(
                        name: "FK_CompaniesAccounts_Accounts_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Accounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesAccounts_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdComp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesAssociates",
                columns: table => new
                {
                    IdCompanyBraider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    IdAssociate = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesAssociates", x => x.IdCompanyBraider);
                    table.ForeignKey(
                        name: "FK_CompaniesAssociates_Associates_IdAssociate",
                        column: x => x.IdAssociate,
                        principalTable: "Associates",
                        principalColumn: "IdAssociate",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesAssociates_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdComp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesClients",
                columns: table => new
                {
                    IdCompanyClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesClients", x => x.IdCompanyClient);
                    table.ForeignKey(
                        name: "FK_CompaniesClients_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompaniesClients_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdComp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IDClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FnameClient = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MnameClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LnameClient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneClient = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    SexClient = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    DOBClient = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Client", x => x.IDClient);
                    table.ForeignKey(
                        name: "FK_Client_User_UserIDUser",
                        column: x => x.UserIDUser,
                        principalTable: "User",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associates_UserIdUser",
                table: "Associates",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserIDUser",
                table: "Client",
                column: "UserIDUser");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAccounts_IdAccount",
                table: "CompaniesAccounts",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAccounts_IdCompany",
                table: "CompaniesAccounts",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAssociates_IdAssociate",
                table: "CompaniesAssociates",
                column: "IdAssociate");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAssociates_IdCompany",
                table: "CompaniesAssociates",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesClients_IdClient",
                table: "CompaniesClients",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesClients_IdCompany",
                table: "CompaniesClients",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AccountIdAccount",
                table: "Subscriptions",
                column: "AccountIdAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Client_clientIDClient",
                table: "Appointments",
                column: "clientIDClient",
                principalTable: "Client",
                principalColumn: "IDClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserIdUser",
                table: "Clients",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Client_clientIDClient",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserIdUser",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CompaniesAccounts");

            migrationBuilder.DropTable(
                name: "CompaniesAssociates");

            migrationBuilder.DropTable(
                name: "CompaniesClients");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Associates");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "IDUser");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Clients",
                newName: "UserIDUser");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Clients",
                newName: "IDUser");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Clients",
                newName: "IDClient");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserIdUser",
                table: "Clients",
                newName: "IX_Clients_UserIDUser");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_clientIDClient",
                table: "Appointments",
                column: "clientIDClient",
                principalTable: "Clients",
                principalColumn: "IDClient",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserIDUser",
                table: "Clients",
                column: "UserIDUser",
                principalTable: "Users",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
