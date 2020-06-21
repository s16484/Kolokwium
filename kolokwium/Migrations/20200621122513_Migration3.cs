using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 1, "Andrzej", "Kowalski", "AK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 1);
        }
    }
}
