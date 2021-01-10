using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddPermissionAndPermissionUserSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_PermissionId",
                table: "PermissionUser");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1L, "add post", "add_post" },
                    { 2L, "edit post", "edit_post" },
                    { 3L, "delete post", "delete_post" },
                    { 4L, "add category", "add_category" },
                    { 5L, "edit category", "edit_category" },
                    { 6L, "delete category", "delete_category" },
                    { 7L, "add tag", "add_tag" },
                    { 8L, "edit tag", "edit_tag" },
                    { 9L, "delete tag", "delete_tag" },
                    { 10L, "add comment", "add_comment" },
                    { 11L, "edit comment", "edit_comment" },
                    { 12L, "delete comment", "delete_comment" },
                    { 13L, "add user", "add_user" },
                    { 14L, "edit user", "edit_user" },
                    { 15L, "activate deactivate user", "activate_deactivate_user" }
                });

            migrationBuilder.InsertData(
                table: "PermissionUser",
                columns: new[] { "PermissionUserId", "PermissionId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 22L, 13L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 21L, 12L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 20L, 12L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 19L, 11L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 18L, 11L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 17L, 10L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 16L, 10L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 15L, 9L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 14L, 9L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 13L, 8L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 12L, 8L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 11L, 7L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 10L, 7L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 9L, 6L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 8L, 5L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 7L, 4L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 6L, 3L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 5L, 3L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 4L, 2L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 3L, 2L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 2L, 1L, "d373e67d-eb8d-44da-bf8b-f13c2410de76" },
                    { 23L, 14L, "5c49772c-a43f-45d5-be7b-55a877a3644e" },
                    { 24L, 15L, "5c49772c-a43f-45d5-be7b-55a877a3644e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_PermissionId_UserId",
                table: "PermissionUser",
                columns: new[] { "PermissionId", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_PermissionId_UserId",
                table: "PermissionUser");

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "PermissionUser",
                keyColumn: "PermissionUserId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 15L);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_PermissionId",
                table: "PermissionUser",
                column: "PermissionId");
        }
    }
}
