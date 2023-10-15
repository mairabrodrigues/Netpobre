using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netpobre.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stars",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_IdShow",
                table: "Stars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stars",
                table: "Stars",
                columns: new[] { "IdShow", "IdClient" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                columns: new[] { "Show", "Price" });

            migrationBuilder.CreateIndex(
                name: "IX_Stars_IdClient",
                table: "Stars",
                column: "IdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stars",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Stars_IdClient",
                table: "Stars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stars",
                table: "Stars",
                column: "IdClient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                column: "Show");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_IdShow",
                table: "Stars",
                column: "IdShow");
        }
    }
}
