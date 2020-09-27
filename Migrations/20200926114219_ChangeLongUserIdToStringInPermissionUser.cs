using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class ChangeLongUserIdToStringInPermissionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UserId1",
                table: "PermissionUser");

            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_UserId1",
                table: "PermissionUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "757c5db6-2d1b-4957-b301-3fddafb89fee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "895078dc-1225-4c5b-be43-2ff61cdca597" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "a3a0a50c-3c43-4609-8be0-782aaf42f075" });

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PermissionUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PermissionUser",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UserId",
                table: "PermissionUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UserId",
                table: "PermissionUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UserId",
                table: "PermissionUser");

            migrationBuilder.DropIndex(
                name: "IX_PermissionUser_UserId",
                table: "PermissionUser");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PermissionUser",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PermissionUser",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "895078dc-1225-4c5b-be43-2ff61cdca597" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "a3a0a50c-3c43-4609-8be0-782aaf42f075" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "757c5db6-2d1b-4957-b301-3fddafb89fee" });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UserId1",
                table: "PermissionUser",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UserId1",
                table: "PermissionUser",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
