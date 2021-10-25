using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ModifyControlsProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "RiskCategoryId",
                table: "Control",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Risk_Code",
                table: "Risk",
                column: "Code",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Control_RiskCategoryId",
                table: "Control",
                column: "RiskCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_RiskCategory_RiskCategoryId",
                table: "Control",
                column: "RiskCategoryId",
                principalTable: "RiskCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_RiskCategory_RiskCategoryId",
                table: "Control");

            migrationBuilder.DropIndex(
                name: "IX_Risk_Code",
                table: "Risk");

            migrationBuilder.DropIndex(
                name: "IX_Control_RiskCategoryId",
                table: "Control");

            migrationBuilder.DropColumn(
                name: "RiskCategoryId",
                table: "Control");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
