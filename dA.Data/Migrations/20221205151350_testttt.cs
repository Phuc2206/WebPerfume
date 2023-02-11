using Microsoft.EntityFrameworkCore.Migrations;

namespace dA.Data.Migrations
{
    public partial class testttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSystem",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSystem", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "AppSystem",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "logo", "" },
                    { "BrandName", "PT.PerFume" },
                    { "Address", "Cần Thơ" },
                    { "Phone", "068686868" },
                    { "Email", "vnpmphuc090701@gmail.com" },
                    { "DefautImg", "" },
                    { "Icon", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSystem");
        }
    }
}
