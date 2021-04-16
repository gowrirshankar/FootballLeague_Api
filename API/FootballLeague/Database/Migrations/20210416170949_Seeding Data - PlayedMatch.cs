using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SeedingDataPlayedMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_MatchesPlayed",
                columns: new[] { "ID", "Draw", "Lost", "MatchesPlayed", "Points", "TeamId", "Won" },
                values: new object[] { 1, 0, 1, 3, 4, 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_MatchesPlayed",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
