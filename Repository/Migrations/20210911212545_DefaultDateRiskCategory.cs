using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DefaultDateRiskCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Division_UserProfileId",
                table: "Division");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RiskCategory",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Division_UserProfileId",
                table: "Division",
                column: "UserProfileId",
                unique: true,
                filter: "[UserProfileId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Division_UserProfileId",
                table: "Division");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RiskCategory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.CreateIndex(
                name: "IX_Division_UserProfileId",
                table: "Division",
                column: "UserProfileId",
                unique: true);
        }
    }
}
