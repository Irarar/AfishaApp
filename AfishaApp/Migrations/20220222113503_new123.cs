using Microsoft.EntityFrameworkCore.Migrations;

namespace AfishaApp.Migrations
{
    public partial class new123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountTicket",
                table: "Afishas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountTicket",
                table: "Afishas");
        }
    }
}
