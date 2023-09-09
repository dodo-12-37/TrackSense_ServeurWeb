using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrackSense.API.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedRideStatistics",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AverageSpeed = table.Column<double>(type: "double", nullable: true),
                    MaximumSpeed = table.Column<double>(type: "double", nullable: true),
                    Distance = table.Column<double>(type: "double", nullable: true),
                    Duration = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Falls = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedRideStatistics", x => x.CompletedRideId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Altitude = table.Column<double>(type: "double", nullable: false),
                    Speed = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlannedRideStatistics",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AverageSpeed = table.Column<double>(type: "double", nullable: false),
                    MaximumSpeed = table.Column<double>(type: "double", nullable: false),
                    AverageDuration = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRideStatistics", x => x.PlannedRideId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AppartmentNumber = table.Column<string>(type: "longtext", nullable: false),
                    StreetNumber = table.Column<string>(type: "longtext", nullable: false),
                    StreetName = table.Column<string>(type: "longtext", nullable: false),
                    ZipCode = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: false),
                    LocationDTOLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_address_Location_LocationDTOLocationId",
                        column: x => x.LocationDTOLocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlannedRide",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserLogin = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    IsFavorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StatisticsPlannedRideId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRide", x => x.PlannedRideId);
                    table.ForeignKey(
                        name: "FK_PlannedRide_PlannedRideStatistics_StatisticsPlannedRideId",
                        column: x => x.StatisticsPlannedRideId,
                        principalTable: "PlannedRideStatistics",
                        principalColumn: "PlannedRideId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserLogin = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CodePostal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    AddressDTOAddressId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_address_AddressDTOAddressId",
                        column: x => x.AddressDTOAddressId,
                        principalTable: "address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedRide",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserLogin = table.Column<string>(type: "longtext", nullable: false),
                    PlannedRideId = table.Column<Guid>(type: "char(36)", nullable: true),
                    StatisticsCompletedRideId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedRide", x => x.CompletedRideId);
                    table.ForeignKey(
                        name: "FK_CompletedRide_CompletedRideStatistics_StatisticsCompletedRid~",
                        column: x => x.StatisticsCompletedRideId,
                        principalTable: "CompletedRideStatistics",
                        principalColumn: "CompletedRideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedRide_PlannedRide_PlannedRideId",
                        column: x => x.PlannedRideId,
                        principalTable: "PlannedRide",
                        principalColumn: "PlannedRideId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlannedRidePoint",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RideStep = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<double>(type: "double", nullable: false),
                    LocationDTOLocationId = table.Column<int>(type: "int", nullable: false),
                    PlannedRideDTOPlannedRideId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRidePoint", x => new { x.PlannedRideId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_PlannedRidePoint_Location_LocationDTOLocationId",
                        column: x => x.LocationDTOLocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannedRidePoint_PlannedRide_PlannedRideDTOPlannedRideId",
                        column: x => x.PlannedRideDTOPlannedRideId,
                        principalTable: "PlannedRide",
                        principalColumn: "PlannedRideId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(100)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedRidePoint",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "char(36)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RideStep = table.Column<int>(type: "int", nullable: true),
                    Temperature = table.Column<double>(type: "double", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompletedRideDTOCompletedRideId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedRidePoint", x => new { x.CompletedRideId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_CompletedRidePoint_CompletedRide_CompletedRideDTOCompletedRi~",
                        column: x => x.CompletedRideDTOCompletedRideId,
                        principalTable: "CompletedRide",
                        principalColumn: "CompletedRideId");
                    table.ForeignKey(
                        name: "FK_CompletedRidePoint_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_address_LocationDTOLocationId",
                table: "address",
                column: "LocationDTOLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_AddressDTOAddressId",
                table: "AspNetUsers",
                column: "AddressDTOAddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRide_PlannedRideId",
                table: "CompletedRide",
                column: "PlannedRideId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRide_StatisticsCompletedRideId",
                table: "CompletedRide",
                column: "StatisticsCompletedRideId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRidePoint_CompletedRideDTOCompletedRideId",
                table: "CompletedRidePoint",
                column: "CompletedRideDTOCompletedRideId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRidePoint_LocationId",
                table: "CompletedRidePoint",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRide_StatisticsPlannedRideId",
                table: "PlannedRide",
                column: "StatisticsPlannedRideId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRidePoint_LocationDTOLocationId",
                table: "PlannedRidePoint",
                column: "LocationDTOLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRidePoint_PlannedRideDTOPlannedRideId",
                table: "PlannedRidePoint",
                column: "PlannedRideDTOPlannedRideId");
        }

        /// <inheritdoc />
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
                name: "CompletedRidePoint");

            migrationBuilder.DropTable(
                name: "PlannedRidePoint");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CompletedRide");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "CompletedRideStatistics");

            migrationBuilder.DropTable(
                name: "PlannedRide");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "PlannedRideStatistics");
        }
    }
}
