using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class BacklogRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backlogs_Boards_boardId",
                table: "Backlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TempIssues_Backlogs_BacklogId",
                table: "TempIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backlogs",
                table: "Backlogs");

            migrationBuilder.RenameTable(
                name: "Backlogs",
                newName: "Backlog");

            migrationBuilder.RenameIndex(
                name: "IX_Backlogs_boardId",
                table: "Backlog",
                newName: "IX_Backlog_boardId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BacklogId",
                table: "TempIssues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "TempIssues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backlog",
                table: "Backlog",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TempIssues_BoardId",
                table: "TempIssues",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Backlog_Boards_boardId",
                table: "Backlog",
                column: "boardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TempIssues_Backlog_BacklogId",
                table: "TempIssues",
                column: "BacklogId",
                principalTable: "Backlog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TempIssues_Boards_BoardId",
                table: "TempIssues",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backlog_Boards_boardId",
                table: "Backlog");

            migrationBuilder.DropForeignKey(
                name: "FK_TempIssues_Backlog_BacklogId",
                table: "TempIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_TempIssues_Boards_BoardId",
                table: "TempIssues");

            migrationBuilder.DropIndex(
                name: "IX_TempIssues_BoardId",
                table: "TempIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backlog",
                table: "Backlog");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "TempIssues");

            migrationBuilder.RenameTable(
                name: "Backlog",
                newName: "Backlogs");

            migrationBuilder.RenameIndex(
                name: "IX_Backlog_boardId",
                table: "Backlogs",
                newName: "IX_Backlogs_boardId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BacklogId",
                table: "TempIssues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backlogs",
                table: "Backlogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Backlogs_Boards_boardId",
                table: "Backlogs",
                column: "boardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TempIssues_Backlogs_BacklogId",
                table: "TempIssues",
                column: "BacklogId",
                principalTable: "Backlogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
