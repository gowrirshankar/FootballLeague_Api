using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SeedingDataTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_Team",
                columns: new[] { "TeamId", "TeamCode", "TeamName" },
                values: new object[,]
                {
                    { 1, "Ger", "Germany" },
                    { 2, "Bra", "Brazil" },
                    { 3, "Swe", "Sweden" },
                    { 4, "Por", "Portugal" },
                    { 5, "Ind", "India" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_Team",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_Team",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_Team",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbl_Team",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbl_Team",
                keyColumn: "TeamId",
                keyValue: 5);
        }
    }
}
