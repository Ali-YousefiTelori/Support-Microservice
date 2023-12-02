using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.SupportsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Departmants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Departmants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
