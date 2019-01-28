using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetService.Migrations
{
    public partial class AddTable_BetCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BetCategoryId",
                table: "BetItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BetCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetItems_BetCategoryId",
                table: "BetItems",
                column: "BetCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BetItems_BetCategory_BetCategoryId",
                table: "BetItems",
                column: "BetCategoryId",
                principalTable: "BetCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BetItems_BetCategory_BetCategoryId",
                table: "BetItems");

            migrationBuilder.DropTable(
                name: "BetCategory");

            migrationBuilder.DropIndex(
                name: "IX_BetItems_BetCategoryId",
                table: "BetItems");

            migrationBuilder.DropColumn(
                name: "BetCategoryId",
                table: "BetItems");
        }
    }
}
