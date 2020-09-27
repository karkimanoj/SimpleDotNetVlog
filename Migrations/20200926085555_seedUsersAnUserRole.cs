using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class seedUsersAnUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "895078dc-1225-4c5b-be43-2ff61cdca597", "aba0693b-959c-4246-9ef5-7e80e6cc3656", "superadmin", "SUPERADMIN" },
                    { "a3a0a50c-3c43-4609-8be0-782aaf42f075", "23b6af00-8980-49e7-9d52-3c0bb48d287b", "admin", "ADMIN" },
                    { "757c5db6-2d1b-4957-b301-3fddafb89fee", "c8836d6a-3d1e-446c-b4d9-327b307a03ae", "editor", "EDITOR" },
                    { "deda37d1-6eb5-49e0-99d6-04bdc7f89637", "9864535c-085a-447c-a592-8ad14fe40b97", "blogger", "BLOGGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1e299ddc-4366-499f-887a-246f4a51c0e2", "895078dc-1225-4c5b-be43-2ff61cdca597" },
                    { "5c49772c-a43f-45d5-be7b-55a877a3644e", "895078dc-1225-4c5b-be43-2ff61cdca597" },
                    { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "895078dc-1225-4c5b-be43-2ff61cdca597" },
                    { "1e299ddc-4366-499f-887a-246f4a51c0e2", "a3a0a50c-3c43-4609-8be0-782aaf42f075" },
                    { "5c49772c-a43f-45d5-be7b-55a877a3644e", "a3a0a50c-3c43-4609-8be0-782aaf42f075" },
                    { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "a3a0a50c-3c43-4609-8be0-782aaf42f075" },
                    { "1e299ddc-4366-499f-887a-246f4a51c0e2", "757c5db6-2d1b-4957-b301-3fddafb89fee" },
                    { "5c49772c-a43f-45d5-be7b-55a877a3644e", "757c5db6-2d1b-4957-b301-3fddafb89fee" },
                    { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "757c5db6-2d1b-4957-b301-3fddafb89fee" },
                    { "1e299ddc-4366-499f-887a-246f4a51c0e2", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" },
                    { "5c49772c-a43f-45d5-be7b-55a877a3644e", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" },
                    { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1e299ddc-4366-499f-887a-246f4a51c0e2", "757c5db6-2d1b-4957-b301-3fddafb89fee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1e299ddc-4366-499f-887a-246f4a51c0e2", "895078dc-1225-4c5b-be43-2ff61cdca597" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1e299ddc-4366-499f-887a-246f4a51c0e2", "a3a0a50c-3c43-4609-8be0-782aaf42f075" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1e299ddc-4366-499f-887a-246f4a51c0e2", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c49772c-a43f-45d5-be7b-55a877a3644e", "757c5db6-2d1b-4957-b301-3fddafb89fee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c49772c-a43f-45d5-be7b-55a877a3644e", "895078dc-1225-4c5b-be43-2ff61cdca597" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c49772c-a43f-45d5-be7b-55a877a3644e", "a3a0a50c-3c43-4609-8be0-782aaf42f075" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5c49772c-a43f-45d5-be7b-55a877a3644e", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" });

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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d373e67d-eb8d-44da-bf8b-f13c2410de76", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757c5db6-2d1b-4957-b301-3fddafb89fee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895078dc-1225-4c5b-be43-2ff61cdca597");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a0a50c-3c43-4609-8be0-782aaf42f075");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deda37d1-6eb5-49e0-99d6-04bdc7f89637");
        }
    }
}
