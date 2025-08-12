using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerrorIncidentAPI.Migrations
{
    /// <inheritdoc />
    public partial class CountryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attacker_ClaimedResponsibility",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Attacker_Motive",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Attacker_NumberOfPerpetrators",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Attacker_PerpetratorGroup",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Confidence",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Incidents");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CountryId",
                table: "Incidents",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Countries_CountryId",
                table: "Incidents",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Countries_CountryId",
                table: "Incidents");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_CountryId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Incidents");

            migrationBuilder.AddColumn<bool>(
                name: "Attacker_ClaimedResponsibility",
                table: "Incidents",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attacker_Motive",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Attacker_NumberOfPerpetrators",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attacker_PerpetratorGroup",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Confidence",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Incidents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
