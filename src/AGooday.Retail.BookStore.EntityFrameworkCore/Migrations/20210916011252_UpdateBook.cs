using Microsoft.EntityFrameworkCore.Migrations;

namespace AGooday.Retail.BookStore.Migrations
{
    public partial class UpdateBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BsBooks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BsBooks");
        }
    }
}
