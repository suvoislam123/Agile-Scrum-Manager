using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserComment_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserComment_Comments_CommentId",
                table: "ApplicationUserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserIssue_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserIssue");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserIssue_Issues_IssueId",
                table: "ApplicationUserIssue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserIssue",
                table: "ApplicationUserIssue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserComment",
                table: "ApplicationUserComment");

            migrationBuilder.RenameTable(
                name: "ApplicationUserIssue",
                newName: "ApplicationUserIssues");

            migrationBuilder.RenameTable(
                name: "ApplicationUserComment",
                newName: "ApplicationUserComments");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserIssue_ApplicationUserId",
                table: "ApplicationUserIssues",
                newName: "IX_ApplicationUserIssues_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserComment_ApplicationUserId",
                table: "ApplicationUserComments",
                newName: "IX_ApplicationUserComments_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserIssues",
                table: "ApplicationUserIssues",
                columns: new[] { "IssueId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserComments",
                table: "ApplicationUserComments",
                columns: new[] { "CommentId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserComments_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserComments_Comments_CommentId",
                table: "ApplicationUserComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserIssues_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserIssues",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserIssues_Issues_IssueId",
                table: "ApplicationUserIssues",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserComments_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserComments_Comments_CommentId",
                table: "ApplicationUserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserIssues_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserIssues_Issues_IssueId",
                table: "ApplicationUserIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserIssues",
                table: "ApplicationUserIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserComments",
                table: "ApplicationUserComments");

            migrationBuilder.RenameTable(
                name: "ApplicationUserIssues",
                newName: "ApplicationUserIssue");

            migrationBuilder.RenameTable(
                name: "ApplicationUserComments",
                newName: "ApplicationUserComment");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserIssues_ApplicationUserId",
                table: "ApplicationUserIssue",
                newName: "IX_ApplicationUserIssue_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserComments_ApplicationUserId",
                table: "ApplicationUserComment",
                newName: "IX_ApplicationUserComment_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserIssue",
                table: "ApplicationUserIssue",
                columns: new[] { "IssueId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserComment",
                table: "ApplicationUserComment",
                columns: new[] { "CommentId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserComment_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserComment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserComment_Comments_CommentId",
                table: "ApplicationUserComment",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserIssue_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserIssue",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserIssue_Issues_IssueId",
                table: "ApplicationUserIssue",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
