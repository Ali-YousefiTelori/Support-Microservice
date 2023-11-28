using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.SupportsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Add_isuniqe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketDepartments_TicketId",
                table: "TicketDepartments");

            migrationBuilder.DropIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_TicketId",
                table: "TicketDepartments",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns",
                column: "TicketId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketDepartments_TicketId",
                table: "TicketDepartments");

            migrationBuilder.DropIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_TicketId",
                table: "TicketDepartments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns",
                column: "TicketId");
        }
    }
}
