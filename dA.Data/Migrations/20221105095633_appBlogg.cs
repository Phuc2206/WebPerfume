using Microsoft.EntityFrameworkCore.Migrations;

namespace dA.Data.Migrations
{
    public partial class appBlogg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBlog",
                columns: table => new
                {
                    IdBlog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentBlogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBlog", x => x.IdBlog);
                    table.ForeignKey(
                        name: "FK_AppBlog_AppBlog_ParentBlogId",
                        column: x => x.ParentBlogId,
                        principalTable: "AppBlog",
                        principalColumn: "IdBlog",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBlog_ParentBlogId",
                table: "AppBlog",
                column: "ParentBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBlog_Slug",
                table: "AppBlog",
                column: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBlog");
        }
    }
}
