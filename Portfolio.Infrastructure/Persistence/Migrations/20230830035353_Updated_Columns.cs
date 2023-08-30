using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastUpdatedByuserid",
                schema: "portfolio",
                table: "Users",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByuserid",
                schema: "portfolio",
                table: "Users",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastupdatedsOn",
                schema: "portfolio",
                table: "Users",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedByuserid",
                schema: "portfolio",
                table: "Skills",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByuserid",
                schema: "portfolio",
                table: "Skills",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastupdatedsOn",
                schema: "portfolio",
                table: "Skills",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedByuserid",
                schema: "portfolio",
                table: "Projects",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByuserid",
                schema: "portfolio",
                table: "Projects",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastupdatedsOn",
                schema: "portfolio",
                table: "Projects",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedByuserid",
                schema: "portfolio",
                table: "Contacts",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByuserid",
                schema: "portfolio",
                table: "Contacts",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastupdatedsOn",
                schema: "portfolio",
                table: "Contacts",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "lastUpdatedByuserid",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "LastUpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByuserid",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "LastupdatedsOn",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "LastUpdatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                schema: "portfolio",
                table: "Users",
                newName: "lastUpdatedByuserid");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "portfolio",
                table: "Users",
                newName: "CreatedByuserid");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                schema: "portfolio",
                table: "Users",
                newName: "LastupdatedsOn");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                schema: "portfolio",
                table: "Skills",
                newName: "lastUpdatedByuserid");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "portfolio",
                table: "Skills",
                newName: "CreatedByuserid");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                schema: "portfolio",
                table: "Skills",
                newName: "LastupdatedsOn");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                schema: "portfolio",
                table: "Projects",
                newName: "lastUpdatedByuserid");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "portfolio",
                table: "Projects",
                newName: "CreatedByuserid");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                schema: "portfolio",
                table: "Projects",
                newName: "LastupdatedsOn");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                schema: "portfolio",
                table: "Contacts",
                newName: "lastUpdatedByuserid");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "portfolio",
                table: "Contacts",
                newName: "CreatedByuserid");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                schema: "portfolio",
                table: "Contacts",
                newName: "LastupdatedsOn");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedByUserId",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "lastUpdatedByuserid");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "CreatedByuserid");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                schema: "portfolio",
                table: "ContactMessages",
                newName: "LastupdatedsOn");
        }
    }
}
