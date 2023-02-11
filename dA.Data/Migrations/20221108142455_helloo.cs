using Microsoft.EntityFrameworkCore.Migrations;

namespace dA.Data.Migrations
{
    public partial class helloo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNews_AppNewsCategory_CategoryId",
                table: "AppNews");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNews_AppUserAdmin_UserId",
                table: "AppNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppNewsCategory",
                table: "AppNewsCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppNews",
                table: "AppNews");

            migrationBuilder.RenameTable(
                name: "AppNewsCategory",
                newName: "AppBlogCategory");

            migrationBuilder.RenameTable(
                name: "AppNews",
                newName: "AppBlog");

            migrationBuilder.RenameIndex(
                name: "IX_AppNewsCategory_Slug",
                table: "AppBlogCategory",
                newName: "IX_AppBlogCategory_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_AppNews_UserId",
                table: "AppBlog",
                newName: "IX_AppBlog_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppNews_CategoryId",
                table: "AppBlog",
                newName: "IX_AppBlog_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBlogCategory",
                table: "AppBlogCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBlog",
                table: "AppBlog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppBlogCategory_CategoryId",
                table: "AppBlog",
                column: "CategoryId",
                principalTable: "AppBlogCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppUserAdmin_UserId",
                table: "AppBlog",
                column: "UserId",
                principalTable: "AppUserAdmin",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppBlogCategory_CategoryId",
                table: "AppBlog");

            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppUserAdmin_UserId",
                table: "AppBlog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBlogCategory",
                table: "AppBlogCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBlog",
                table: "AppBlog");

            migrationBuilder.RenameTable(
                name: "AppBlogCategory",
                newName: "AppNewsCategory");

            migrationBuilder.RenameTable(
                name: "AppBlog",
                newName: "AppNews");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlogCategory_Slug",
                table: "AppNewsCategory",
                newName: "IX_AppNewsCategory_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlog_UserId",
                table: "AppNews",
                newName: "IX_AppNews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlog_CategoryId",
                table: "AppNews",
                newName: "IX_AppNews_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppNewsCategory",
                table: "AppNewsCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppNews",
                table: "AppNews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNews_AppNewsCategory_CategoryId",
                table: "AppNews",
                column: "CategoryId",
                principalTable: "AppNewsCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNews_AppUserAdmin_UserId",
                table: "AppNews",
                column: "UserId",
                principalTable: "AppUserAdmin",
                principalColumn: "Id");
        }
    }
}
