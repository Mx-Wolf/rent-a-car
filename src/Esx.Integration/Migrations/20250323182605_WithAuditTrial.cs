using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esx.Integration.Migrations
{
    /// <inheritdoc />
    public partial class WithAuditTrial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTrial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    CompletedByUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CompletedByEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Changes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrial", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrial");
        }
    }
}
