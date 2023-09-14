using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackSense.API.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationToken",
                columns: table => new
                {
                    ApplicationTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applicat__51EA9096072F9446", x => x.ApplicationTokenId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Altitude = table.Column<double>(type: "float", nullable: true),
                    Speed = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA497B2F12385", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserCodePostal = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserLogin);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    AppartmentNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__091C2AFB166146D8", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Credenti__7F8E8D5FB80D981D", x => x.UserLogin);
                    table.ForeignKey(
                        name: "FK_Credential_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "PlannedRide",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isFavorite = table.Column<bool>(type: "bit", nullable: true),
                    UserLoginNavigationUserLogin = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlannedR__807DE2956F2B5FAE", x => x.PlannedRideId);
                    table.ForeignKey(
                        name: "FK_PlannedRide_user_UserLoginNavigationUserLogin",
                        column: x => x.UserLoginNavigationUserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "Tracksense",
                columns: table => new
                {
                    TracksenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastLatitude = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    LastLongitude = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    LastAltitude = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    LastCommunication = table.Column<DateTime>(type: "datetime", nullable: true),
                    isFallen = table.Column<bool>(type: "bit", nullable: true),
                    isStolen = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tracksen__6AF72C603CA58608", x => x.TracksenseId);
                    table.ForeignKey(
                        name: "FK_Tracksense_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "UserStatistics",
                columns: table => new
                {
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AvgSpeed = table.Column<double>(type: "float", nullable: true),
                    MaxSpeed = table.Column<double>(type: "float", nullable: true),
                    Duration = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserStat__7F8E8D5FF90916AF", x => x.UserLogin);
                    table.ForeignKey(
                        name: "FK_UserStatistics_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserToke__BD92DEDB60619A76", x => x.UserTokenId);
                    table.ForeignKey(
                        name: "FK_UserToken_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "InterestPoint",
                columns: table => new
                {
                    InterestPointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interest__E13EB84985BF89F7", x => x.InterestPointId);
                    table.ForeignKey(
                        name: "FK_InterestPoint_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_InterestPoint_User",
                        column: x => x.UserLogin,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "CompletedRide",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlannedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserLogin1 = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__3D404232BE9BF58B", x => x.CompletedRideId);
                    table.ForeignKey(
                        name: "FK_CompletedRide_PlannedRide_PlannedRideId",
                        column: x => x.PlannedRideId,
                        principalTable: "PlannedRide",
                        principalColumn: "PlannedRideId");
                    table.ForeignKey(
                        name: "FK_CompletedRide_user_UserLogin1",
                        column: x => x.UserLogin1,
                        principalTable: "user",
                        principalColumn: "UserLogin");
                });

            migrationBuilder.CreateTable(
                name: "PlannedRidePoint",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RideStep = table.Column<int>(type: "int", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: true),
                    LocationId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlannedR__EE0208DC97FCB4A7", x => new { x.PlannedRideId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_PlannedRidePoint_Location_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannedRidePoint_PlannedRide_PlannedRideId",
                        column: x => x.PlannedRideId,
                        principalTable: "PlannedRide",
                        principalColumn: "PlannedRideId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedRideStatistics",
                columns: table => new
                {
                    PlannedRideId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    AverageSpeed = table.Column<double>(type: "float", nullable: true),
                    AverageDuration = table.Column<double>(type: "float", nullable: true),
                    MaximumSpeed = table.Column<double>(type: "float", nullable: true),
                    Falls = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    Duration = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlannedR__807DE295481CB488", x => x.PlannedRideId);
                    table.ForeignKey(
                        name: "FK_PlannedRideStatistics_PlannedRide_PlannedRideId",
                        column: x => x.PlannedRideId,
                        principalTable: "PlannedRide",
                        principalColumn: "PlannedRideId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedRidePoint",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RideStep = table.Column<int>(type: "int", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__533FA87BD1669A65", x => new { x.CompletedRideId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_CompletedRidePoint_CompletedRide_CompletedRideId",
                        column: x => x.CompletedRideId,
                        principalTable: "CompletedRide",
                        principalColumn: "CompletedRideId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedRidePoint_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedRideStatistics",
                columns: table => new
                {
                    CompletedRideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvgSpeed = table.Column<double>(type: "float", nullable: true),
                    MaxSpeed = table.Column<double>(type: "float", nullable: true),
                    Falls = table.Column<int>(type: "int", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "Time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__3D4042327B20BD26", x => x.CompletedRideId);
                    table.ForeignKey(
                        name: "FK_CompletedRideStatistics_CompletedRide",
                        column: x => x.CompletedRideId,
                        principalTable: "CompletedRide",
                        principalColumn: "CompletedRideId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                table: "Address",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UQ__Applicat__1EB4F8176BA0B319",
                table: "ApplicationToken",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRide_PlannedRideId",
                table: "CompletedRide",
                column: "PlannedRideId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRide_UserLogin1",
                table: "CompletedRide",
                column: "UserLogin1");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedRidePoint_LocationId",
                table: "CompletedRidePoint",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserLogin",
                table: "Contact",
                column: "UserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_AddressId",
                table: "InterestPoint",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPoint_UserLogin",
                table: "InterestPoint",
                column: "UserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRide_UserLoginNavigationUserLogin",
                table: "PlannedRide",
                column: "UserLoginNavigationUserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRidePoint_LocationId1",
                table: "PlannedRidePoint",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "UQ__Tracksen__7F8E8D5EC0100CC1",
                table: "Tracksense",
                column: "UserLogin",
                unique: true,
                filter: "[UserLogin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__user__7F8E8D5EC31A1ED4",
                table: "user",
                column: "UserLogin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserLogin",
                table: "UserToken",
                column: "UserLogin");

            migrationBuilder.CreateIndex(
                name: "UQ__UserToke__1EB4F817FB3EA34C",
                table: "UserToken",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationToken");

            migrationBuilder.DropTable(
                name: "CompletedRidePoint");

            migrationBuilder.DropTable(
                name: "CompletedRideStatistics");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "InterestPoint");

            migrationBuilder.DropTable(
                name: "PlannedRidePoint");

            migrationBuilder.DropTable(
                name: "PlannedRideStatistics");

            migrationBuilder.DropTable(
                name: "Tracksense");

            migrationBuilder.DropTable(
                name: "UserStatistics");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "CompletedRide");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PlannedRide");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
