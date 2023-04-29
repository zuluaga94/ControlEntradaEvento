using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventControl.API.Migrations
{
    /// <inheritdoc />
    public partial class hdp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_eventTickets_Id",
                table: "eventTickets",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_eventTickets_Id",
                table: "eventTickets");
        }
    }
}
