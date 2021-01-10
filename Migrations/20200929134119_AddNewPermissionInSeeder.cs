using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddNewPermissionInSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "DisplayName", "Name" },
                values: new object[] { 16L, "verify post", "verify_post" });

            migrationBuilder.InsertData(
                table: "PermissionUser",
                columns: new[] { "PermissionUserId", "PermissionId", "UserId" },
                values: new object[] { 25L, 16L, "5c49772c-a43f-45d5-be7b-55a877a3644e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 16L);
        }
    }
}
