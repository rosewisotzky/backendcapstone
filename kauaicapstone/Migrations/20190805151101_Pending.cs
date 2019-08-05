using Microsoft.EntityFrameworkCore.Migrations;

namespace kauaicapstone.Migrations
{
    public partial class Pending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2b12c57-375e-40a2-a3b4-c7cb93cad6c8", "AQAAAAEAACcQAAAAEPjsawpI/7x7gb1KqcvgZUZHW2aTmauwRwSBulPyQUIfeaCGB3dMphoVgu37EOdwow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000001-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "232a96e4-537e-4307-bcbe-94324365d6cf", "AQAAAAEAACcQAAAAEB+IOhcGbAyBWTGdcy6GVxYe71n0+axAyu3xipMcf+jrb75uBznhqYzYzvZo/dqGBg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "867617ee-cbf9-42b0-a544-90601d1f5b92", "AQAAAAEAACcQAAAAEM+yQwnZsPwCLxsAr6bgnkww1vfI0V/5Y8VP792RcR9IYBxj7LxHwXr3iiyEa182hA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000001-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea75bdc0-0612-426b-8f70-4eaac4414a51", "AQAAAAEAACcQAAAAEFYPpGXuUDR1prs0zOTTgm9BoEVH7JYhRPG5YpwDhmZCdNOnwAasnjOz9tQSrnuU4Q==" });
        }
    }
}
