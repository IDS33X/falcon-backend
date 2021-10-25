using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ControlModelRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskControl_Control_ControlId",
                table: "RiskControl");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskControl_Risk_RiskId",
                table: "RiskControl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiskControl",
                table: "RiskControl");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserControl");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RiskControl");

            migrationBuilder.RenameTable(
                name: "RiskControl",
                newName: "RisKControl");

            migrationBuilder.RenameIndex(
                name: "IX_RiskControl_RiskId",
                table: "RisKControl",
                newName: "IX_RisKControl_RiskId");

            migrationBuilder.RenameColumn(
                name: "ResponsiblePosition",
                table: "Control",
                newName: "ResponsablePosition");

            migrationBuilder.RenameColumn(
                name: "Ojective",
                table: "Control",
                newName: "Objective");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RiskCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MRole",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MControlType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MControlState",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MAutomationLevel",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ImpactType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Division",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Department",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Area",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RisKControl",
                table: "RisKControl",
                columns: new[] { "ControlId", "RiskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RisKControl_Control_ControlId",
                table: "RisKControl",
                column: "ControlId",
                principalTable: "Control",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RisKControl_Risk_RiskId",
                table: "RisKControl",
                column: "RiskId",
                principalTable: "Risk",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);


           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RisKControl_Control_ControlId",
                table: "RisKControl");

            migrationBuilder.DropForeignKey(
                name: "FK_RisKControl_Risk_RiskId",
                table: "RisKControl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RisKControl",
                table: "RisKControl");

            migrationBuilder.RenameTable(
                name: "RisKControl",
                newName: "RiskControl");

            migrationBuilder.RenameIndex(
                name: "IX_RisKControl_RiskId",
                table: "RiskControl",
                newName: "IX_RiskControl_RiskId");

            migrationBuilder.RenameColumn(
                name: "ResponsablePosition",
                table: "Control",
                newName: "ResponsiblePosition");

            migrationBuilder.RenameColumn(
                name: "Objective",
                table: "Control",
                newName: "Ojective");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserControl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RiskControl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RiskCategory",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MRole",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MControlType",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MControlState",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MAutomationLevel",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ImpactType",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Division",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Department",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Area",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiskControl",
                table: "RiskControl",
                columns: new[] { "ControlId", "RiskId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RiskControl_Control_ControlId",
                table: "RiskControl",
                column: "ControlId",
                principalTable: "Control",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskControl_Risk_RiskId",
                table: "RiskControl",
                column: "RiskId",
                principalTable: "Risk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
