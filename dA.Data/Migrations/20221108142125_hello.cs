using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dA.Data.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBlog_AppBlog_ParentBlogId",
                table: "AppBlog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBlog",
                table: "AppBlog");

            migrationBuilder.DropIndex(
                name: "IX_AppBlog_Slug",
                table: "AppBlog");

            migrationBuilder.RenameTable(
                name: "AppBlog",
                newName: "AppNews");

            migrationBuilder.RenameColumn(
                name: "ParentBlogId",
                table: "AppNews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdBlog",
                table: "AppNews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppBlog_ParentBlogId",
                table: "AppNews",
                newName: "IX_AppNews_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AppNews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "AppNews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AppNews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImgPath",
                table: "AppNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImgThumbnailPath",
                table: "AppNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AppNews",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "AppNews",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "AppNews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StampPath",
                table: "AppNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "AppNews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Views",
                table: "AppNews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "Votes",
                table: "AppNews",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppNews",
                table: "AppNews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppNewsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNewsCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNews_CategoryId",
                table: "AppNews",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "uq_slug",
                table: "AppNews",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppNewsCategory_Slug",
                table: "AppNewsCategory",
                column: "Slug");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNews_AppNewsCategory_CategoryId",
                table: "AppNews");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNews_AppUserAdmin_UserId",
                table: "AppNews");

            migrationBuilder.DropTable(
                name: "AppNewsCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppNews",
                table: "AppNews");

            migrationBuilder.DropIndex(
                name: "IX_AppNews_CategoryId",
                table: "AppNews");

            migrationBuilder.DropIndex(
                name: "uq_slug",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "CoverImgPath",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "CoverImgThumbnailPath",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "StampPath",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "AppNews");

            migrationBuilder.DropColumn(
                name: "Votes",
                table: "AppNews");

            migrationBuilder.RenameTable(
                name: "AppNews",
                newName: "AppBlog");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppBlog",
                newName: "ParentBlogId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppBlog",
                newName: "IdBlog");

            migrationBuilder.RenameIndex(
                name: "IX_AppNews_UserId",
                table: "AppBlog",
                newName: "IX_AppBlog_ParentBlogId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AppBlog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "AppBlog",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBlog",
                table: "AppBlog",
                column: "IdBlog");

            migrationBuilder.CreateIndex(
                name: "IX_AppBlog_Slug",
                table: "AppBlog",
                column: "Slug");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBlog_AppBlog_ParentBlogId",
                table: "AppBlog",
                column: "ParentBlogId",
                principalTable: "AppBlog",
                principalColumn: "IdBlog",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
