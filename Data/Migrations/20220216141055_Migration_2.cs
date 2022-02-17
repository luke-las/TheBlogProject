using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBlogProject.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageDate",
                table: "Posts",
                newName: "ImageData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Posts",
                newName: "ImageDate");
        }
    }
}
