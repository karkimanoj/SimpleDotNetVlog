using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SeedRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "895078dc-1225-4c5b-be43-2ff61cdca597", "aba0693b-959c-4246-9ef5-7e80e6cc3656", "superadmin", null },
                    { "a3a0a50c-3c43-4609-8be0-782aaf42f075", "23b6af00-8980-49e7-9d52-3c0bb48d287b", "admin", null },
                    { "757c5db6-2d1b-4957-b301-3fddafb89fee", "c8836d6a-3d1e-446c-b4d9-327b307a03ae", "editor", null },
                    { "deda37d1-6eb5-49e0-99d6-04bdc7f89637", "9864535c-085a-447c-a592-8ad14fe40b97", "blogger", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f20a54b-68b7-4634-a1df-963513c3e415", 0, "b03f20b8-aceb-4b0d-acea-92525a53f72c", "superadmin@blog.com", true, false, null, "superadmin@BLOG.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEOHhG6FMHmJNcz+9Csw7+G3z0LhEr8qSVEnxaa4FfpRT9jP0Z9MLFFVPpIQGO/6PtQ==", "+111111111111", true, "37846ea2-3747-44ed-a173-b1a6faca7b37", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "9f20a54b-68b7-4634-a1df-963513c3e415", "895078dc-1225-4c5b-be43-2ff61cdca597" },
                    { "9f20a54b-68b7-4634-a1df-963513c3e415", "a3a0a50c-3c43-4609-8be0-782aaf42f075" },
                    { "9f20a54b-68b7-4634-a1df-963513c3e415", "757c5db6-2d1b-4957-b301-3fddafb89fee" },
                    { "9f20a54b-68b7-4634-a1df-963513c3e415", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9f20a54b-68b7-4634-a1df-963513c3e415", "757c5db6-2d1b-4957-b301-3fddafb89fee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9f20a54b-68b7-4634-a1df-963513c3e415", "895078dc-1225-4c5b-be43-2ff61cdca597" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9f20a54b-68b7-4634-a1df-963513c3e415", "a3a0a50c-3c43-4609-8be0-782aaf42f075" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "9f20a54b-68b7-4634-a1df-963513c3e415", "deda37d1-6eb5-49e0-99d6-04bdc7f89637" });

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f20a54b-68b7-4634-a1df-963513c3e415");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
