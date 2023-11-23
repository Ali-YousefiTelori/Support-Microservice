using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMicroservices.SupportsMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketAssigns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAssigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SensitivityStatus = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketSupportTimeHistoryHistories",
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
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSupportTimeHistoryHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UniqueIdentity = table.Column<string>(type: "nvarchar(450)", nullable: true, collation: "SQL_Latin1_General_CP1_CS_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDepartments_Departmants_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departmants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketDepartments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketHistories",
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
                    table.PrimaryKey("PK_TicketHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketHistories_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_CreationDateTime",
                table: "Departmants",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_DeletedDateTime",
                table: "Departmants",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_IsDeleted",
                table: "Departmants",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_ModificationDateTime",
                table: "Departmants",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_UniqueIdentity",
                table: "Departmants",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_CreationDateTime",
                table: "TicketAssigns",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_DeletedDateTime",
                table: "TicketAssigns",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_IsDeleted",
                table: "TicketAssigns",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_ModificationDateTime",
                table: "TicketAssigns",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAssigns_UniqueIdentity",
                table: "TicketAssigns",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_CreationDateTime",
                table: "TicketDepartments",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_DeletedDateTime",
                table: "TicketDepartments",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_DepartmentId",
                table: "TicketDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_IsDeleted",
                table: "TicketDepartments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_ModificationDateTime",
                table: "TicketDepartments",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_TicketId",
                table: "TicketDepartments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDepartments_UniqueIdentity",
                table: "TicketDepartments",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_CreationDateTime",
                table: "TicketHistories",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_DeletedDateTime",
                table: "TicketHistories",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_IsDeleted",
                table: "TicketHistories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_ModificationDateTime",
                table: "TicketHistories",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_TicketId",
                table: "TicketHistories",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_UniqueIdentity",
                table: "TicketHistories",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreationDateTime",
                table: "Tickets",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DeletedDateTime",
                table: "Tickets",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IsDeleted",
                table: "Tickets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ModificationDateTime",
                table: "Tickets",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UniqueIdentity",
                table: "Tickets",
                column: "UniqueIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistoryHistories_CreationDateTime",
                table: "TicketSupportTimeHistoryHistories",
                column: "CreationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistoryHistories_DeletedDateTime",
                table: "TicketSupportTimeHistoryHistories",
                column: "DeletedDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistoryHistories_IsDeleted",
                table: "TicketSupportTimeHistoryHistories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistoryHistories_ModificationDateTime",
                table: "TicketSupportTimeHistoryHistories",
                column: "ModificationDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupportTimeHistoryHistories_UniqueIdentity",
                table: "TicketSupportTimeHistoryHistories",
                column: "UniqueIdentity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAssigns");

            migrationBuilder.DropTable(
                name: "TicketDepartments");

            migrationBuilder.DropTable(
                name: "TicketHistories");

            migrationBuilder.DropTable(
                name: "TicketSupportTimeHistoryHistories");

            migrationBuilder.DropTable(
                name: "Departmants");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
