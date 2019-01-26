using Microsoft.EntityFrameworkCore.Migrations;

namespace Crawler.Migrations
{
    public partial class AlterUriBetToParseAddColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UrisBetsToParse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UrisBetsToParse");
        }
    }
}
