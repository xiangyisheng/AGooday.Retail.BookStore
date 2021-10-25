using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGooday.Retail.BookStore.Migrations
{
    public partial class AddedMultiTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "BsBooks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "BsAuthors",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "BsBooks");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "BsAuthors");
        }
    }
}
