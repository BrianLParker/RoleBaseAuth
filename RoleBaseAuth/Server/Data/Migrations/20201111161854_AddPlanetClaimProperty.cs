using Microsoft.EntityFrameworkCore.Migrations;

namespace RoleBaseAuth.Server.Data.Migrations
{
    public partial class AddPlanetClaimProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) => migrationBuilder.AddColumn<string>(
                name: "Planet",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

        protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropColumn(
                name: "Planet",
                table: "AspNetUsers");
    }
}
