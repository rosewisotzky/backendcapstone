using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kauaicapstone.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "ViewLocation",
                columns: table => new
                {
                    ViewLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ViewPointAddress = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewLocation", x => x.ViewLocationId);
                    table.ForeignKey(
                        name: "FK_ViewLocation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ViewLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_ViewLocation_ViewLocationId",
                        column: x => x.ViewLocationId,
                        principalTable: "ViewLocation",
                        principalColumn: "ViewLocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Legend",
                columns: table => new
                {
                    LegendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    ViewLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legend", x => x.LegendId);
                    table.ForeignKey(
                        name: "FK_Legend_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Legend_ViewLocation_ViewLocationId",
                        column: x => x.ViewLocationId,
                        principalTable: "ViewLocation",
                        principalColumn: "ViewLocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegendViewLocation",
                columns: table => new
                {
                    LegendViewLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LegendId = table.Column<int>(nullable: false),
                    ViewLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegendViewLocation", x => x.LegendViewLocationId);
                    table.ForeignKey(
                        name: "FK_LegendViewLocation_Legend_LegendId",
                        column: x => x.LegendId,
                        principalTable: "Legend",
                        principalColumn: "LegendId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegendViewLocation_ViewLocation_ViewLocationId",
                        column: x => x.ViewLocationId,
                        principalTable: "ViewLocation",
                        principalColumn: "ViewLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "11856b00-bf9a-4357-a1c1-1afa654a396e", "admin@admin.com", true, "admin", false, "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAgVhV+CRlKOFLRV/hXPBlkLYhopHjidw7cVcTI+kIfk3XnBMqcCFnkAgVKVLl5haQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000001-ffff-ffff-ffff-ffffffffffff", 0, "c87a1417-b979-4f5a-8333-999ce225bf91", "rose@rose.com", true, "Rose", false, "Wisotzky", false, null, "ROSE@ROSE.COM", "ROSE@ROSE.COM", "AQAAAAEAACcQAAAAEL1g82Oo3gmiRtYEcBWk12FETfiFoEfpt/9ZZYTBzJWWzDQsSsZ8K0gmrnENsHXVkQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794578", false, "rose@rose.com" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "DatePosted", "LocationId", "Message", "UserId", "ViewLocationId" },
                values: new object[] { 1, new DateTime(2019, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "You can also visit the dry caves from Makua Beach, the bridge will be closed if there is heavy rain", "00000001-ffff-ffff-ffff-ffffffffffff", null });

            migrationBuilder.InsertData(
                table: "Legend",
                columns: new[] { "LegendId", "Description", "ImageURL", "IsApproved", "Source", "Title", "UserId", "ViewLocationId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.", null, false, "Kauai Tales by Frederick Bruce Wichman", "Na-Piliwale", "00000001-ffff-ffff-ffff-ffffffffffff", null },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.", null, false, "Kauai Tales by Frederick Bruce Wichman", "Pohaku-o-Kane", "00000001-ffff-ffff-ffff-ffffffffffff", null },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.", null, false, "Kauai Tales by Frederick Bruce Wichman", "Kanaka-Nunui-Moa", "00000001-ffff-ffff-ffff-ffffffffffff", null },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.", null, false, "Kauai Tales by Frederick Bruce Wichman", "Nou O Makana", "00000001-ffff-ffff-ffff-ffffffffffff", null }
                });

            migrationBuilder.InsertData(
                table: "ViewLocation",
                columns: new[] { "ViewLocationId", "Name", "UserId", "ViewPointAddress" },
                values: new object[,]
                {
                    { 1, "Makua Beach", "00000001-ffff-ffff-ffff-ffffffffffff", "HI-560, Kapaʻa, HI 96746" },
                    { 2, "Limahuli Garden & Preserve", "00000001-ffff-ffff-ffff-ffffffffffff", "5-8291 Kuhio Hwy, Hanalei, HI 96714" },
                    { 3, "Kalalau Valley", "00000001-ffff-ffff-ffff-ffffffffffff", "5-8291 Kuhio Hwy, Hanalei, HI 96714" },
                    { 4, "Sleeping Giant Trail", "00000001-ffff-ffff-ffff-ffffffffffff", "Sleeping Giant, Wailua, HI 96746" }
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
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ViewLocationId",
                table: "Comment",
                column: "ViewLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Legend_UserId",
                table: "Legend",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Legend_ViewLocationId",
                table: "Legend",
                column: "ViewLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LegendViewLocation_LegendId",
                table: "LegendViewLocation",
                column: "LegendId");

            migrationBuilder.CreateIndex(
                name: "IX_LegendViewLocation_ViewLocationId",
                table: "LegendViewLocation",
                column: "ViewLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewLocation_UserId",
                table: "ViewLocation",
                column: "UserId");
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
                name: "Comment");

            migrationBuilder.DropTable(
                name: "LegendViewLocation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Legend");

            migrationBuilder.DropTable(
                name: "ViewLocation");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
