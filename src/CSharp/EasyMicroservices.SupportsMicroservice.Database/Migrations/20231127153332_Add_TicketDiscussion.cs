using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.SupportsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Add_TicketDiscussion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSupportTimeHistoryHistories",
                table: "TicketSupportTimeHistoryHistories");

            migrationBuilder.RenameTable(
                name: "TicketSupportTimeHistoryHistories",
                newName: "TicketSupportTimeHistories");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistoryHistories_UniqueIdentity",
                table: "TicketSupportTimeHistories",
                newName: "IX_TicketSupportTimeHistories_UniqueIdentity");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistoryHistories_ModificationDateTime",
                table: "TicketSupportTimeHistories",
                newName: "IX_TicketSupportTimeHistories_ModificationDateTime");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistoryHistories_IsDeleted",
                table: "TicketSupportTimeHistories",
                newName: "IX_TicketSupportTimeHistories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistoryHistories_DeletedDateTime",
                table: "TicketSupportTimeHistories",
                newName: "IX_TicketSupportTimeHistories_DeletedDateTime");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistoryHistories_CreationDateTime",
                table: "TicketSupportTimeHistories",
                newName: "IX_TicketSupportTimeHistories_CreationDateTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSupportTimeHistories",
                table: "TicketSupportTimeHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketDiscussions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDiscussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDiscussions_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistories_TicketId",
                table: "TicketSupportTimeHistories",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_CreationDateTime",
                table: "TicketDiscussions",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_DeletedDateTime",
                table: "TicketDiscussions",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_IsDeleted",
                table: "TicketDiscussions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_ModificationDateTime",
                table: "TicketDiscussions",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_TicketId",
                table: "TicketDiscussions",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDiscussions_UniqueIdentity",
                table: "TicketDiscussions",
                column: "UniqueIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAssigns_Tickets_TicketId",
                table: "TicketAssigns",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSupportTimeHistories_Tickets_TicketId",
                table: "TicketSupportTimeHistories",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketAssigns_Tickets_TicketId",
                table: "TicketAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSupportTimeHistories_Tickets_TicketId",
                table: "TicketSupportTimeHistories");

            migrationBuilder.DropTable(
                name: "TicketDiscussions");

            migrationBuilder.DropIndex(
                name: "IX_TicketAssigns_TicketId",
                table: "TicketAssigns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSupportTimeHistories",
                table: "TicketSupportTimeHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketSupportTimeHistories_TicketId",
                table: "TicketSupportTimeHistories");

            migrationBuilder.RenameTable(
                name: "TicketSupportTimeHistories",
                newName: "TicketSupportTimeHistoryHistories");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistories_UniqueIdentity",
                table: "TicketSupportTimeHistoryHistories",
                newName: "IX_TicketSupportTimeHistoryHistories_UniqueIdentity");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistories_ModificationDateTime",
                table: "TicketSupportTimeHistoryHistories",
                newName: "IX_TicketSupportTimeHistoryHistories_ModificationDateTime");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistories_IsDeleted",
                table: "TicketSupportTimeHistoryHistories",
                newName: "IX_TicketSupportTimeHistoryHistories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistories_DeletedDateTime",
                table: "TicketSupportTimeHistoryHistories",
                newName: "IX_TicketSupportTimeHistoryHistories_DeletedDateTime");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSupportTimeHistories_CreationDateTime",
                table: "TicketSupportTimeHistoryHistories",
                newName: "IX_TicketSupportTimeHistoryHistories_CreationDateTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSupportTimeHistoryHistories",
                table: "TicketSupportTimeHistoryHistories",
                column: "Id");
        }
    }
}
