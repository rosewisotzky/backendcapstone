using Microsoft.EntityFrameworkCore.Migrations;

namespace kauaicapstone.Migrations
{
    public partial class UserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "IsAdmin", "PasswordHash" },
                values: new object[] { "7a79021d-9b69-43fe-82c9-ac7355809936", true, "AQAAAAEAACcQAAAAEJ3Fxvd3W8J29VFV7cJfGxviMTjzJyytmAMN6jrMnaxPoN5jOc/+SIzehukEBdpReQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000001-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2c6e529-bda5-4905-8797-6a71260f0ed9", "AQAAAAEAACcQAAAAEJwe8sqMTnnQ1ssYHpirpphB0Zs4yunKMstERSSqlPW7bek1AqYFNBsUC1dLh73p6A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "IsAdmin", "PasswordHash" },
                values: new object[] { "41948a3b-01b1-436e-944d-18e03b4d3766", false, "AQAAAAEAACcQAAAAEJDcRBdlRxtGO1R5Fr/K97w/R0z5w+TdJj8dkJGP7qjYRA11YmRrgedF+nRwylcyoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000001-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9f4e338-87e5-492c-ac33-50001ccb4608", "AQAAAAEAACcQAAAAEDCS/9TqOwspPXexA+eqiCUGW75hIyn15RVEHAvMR50rDr82pxJfQgiwyJVGmCNhqg==" });
        }
    }
}
