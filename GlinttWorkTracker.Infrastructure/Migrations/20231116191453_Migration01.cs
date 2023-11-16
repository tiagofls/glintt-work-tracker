using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlinttWorkTracker.Infrastructure.Migrations
{
    public partial class Migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GlinttApp = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Epic = table.Column<string>(type: "TEXT", nullable: false),
                    IdIssue = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdWork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GlinttApp = table.Column<string>(type: "TEXT", nullable: false),
                    Project = table.Column<string>(type: "TEXT", nullable: false),
                    AuxProject = table.Column<string>(type: "TEXT", nullable: false),
                    File = table.Column<string>(type: "TEXT", nullable: false),
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdWork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeChanges_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataBaseChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Database = table.Column<string>(type: "TEXT", nullable: false),
                    UserPwd = table.Column<string>(type: "TEXT", nullable: false),
                    Package = table.Column<string>(type: "TEXT", nullable: false),
                    Method = table.Column<string>(type: "TEXT", nullable: false),
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdWork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBaseChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataBaseChanges_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DBScripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Database = table.Column<string>(type: "TEXT", nullable: false),
                    UserPwd = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdWork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBScripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBScripts_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NuGetUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NuGet = table.Column<string>(type: "TEXT", nullable: false),
                    Where = table.Column<string>(type: "TEXT", nullable: false),
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdWork = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NuGetUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NuGetUpdates_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeChanges_WorkId",
                table: "CodeChanges",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_DataBaseChanges_WorkId",
                table: "DataBaseChanges",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_DBScripts_WorkId",
                table: "DBScripts",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_NuGetUpdates_WorkId",
                table: "NuGetUpdates",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeChanges");

            migrationBuilder.DropTable(
                name: "DataBaseChanges");

            migrationBuilder.DropTable(
                name: "DBScripts");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "NuGetUpdates");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
