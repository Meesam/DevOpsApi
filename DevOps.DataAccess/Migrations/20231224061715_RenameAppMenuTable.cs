using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevOps.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameAppMenuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appMenus",
                table: "appMenus");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133dc474-2788-4de7-ad6c-d6224b7f10ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a0bf26-b05b-4839-8d72-c847b6a695be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dde76f08-d5b3-4567-9531-3ddfd6379e43");

            migrationBuilder.RenameTable(
                name: "appMenus",
                newName: "AppMenus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppMenus",
                table: "AppMenus",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppMenus",
                table: "AppMenus");

            migrationBuilder.RenameTable(
                name: "AppMenus",
                newName: "appMenus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appMenus",
                table: "appMenus",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "133dc474-2788-4de7-ad6c-d6224b7f10ba", "1", "Admin", "Admin" },
                    { "d1a0bf26-b05b-4839-8d72-c847b6a695be", "3", "Client", "Client" },
                    { "dde76f08-d5b3-4567-9531-3ddfd6379e43", "2", "User", "User" }
                });
        }
    }
}
