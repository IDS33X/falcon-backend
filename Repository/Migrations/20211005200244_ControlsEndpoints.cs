using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ControlsEndpoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImpactType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MAutomationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAutomationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MControlState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MControlState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MControlType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MControlType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskImpact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpactTypeId = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskImpact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskImpact_ImpactType_ImpactTypeId",
                        column: x => x.ImpactTypeId,
                        principalTable: "ImpactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Control",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Documented = table.Column<bool>(type: "bit", nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResponsiblePosition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    Activity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ojective = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Evidence = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AutomationLevelId = table.Column<int>(type: "int", nullable: false),
                    ControlStateId = table.Column<int>(type: "int", nullable: false),
                    ControlTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Control_MAutomationLevel_AutomationLevelId",
                        column: x => x.AutomationLevelId,
                        principalTable: "MAutomationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Control_MControlState_ControlStateId",
                        column: x => x.ControlStateId,
                        principalTable: "MControlState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Control_MControlType_ControlTypeId",
                        column: x => x.ControlTypeId,
                        principalTable: "MControlType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Control_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RiskCategoryId = table.Column<int>(type: "int", nullable: false),
                    InherentRiskId = table.Column<int>(type: "int", nullable: false),
                    ControlledRiskId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risk_RiskCategory_RiskCategoryId",
                        column: x => x.RiskCategoryId,
                        principalTable: "RiskCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Risk_RiskImpact_ControlledRiskId",
                        column: x => x.ControlledRiskId,
                        principalTable: "RiskImpact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_RiskImpact_InherentRiskId",
                        column: x => x.InherentRiskId,
                        principalTable: "RiskImpact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Risk_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserControl",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DeallocatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserControl", x => new { x.ControlId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserControl_Control_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Control",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserControl_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RiskControl",
                columns: table => new
                {
                    RiskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DeallocatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskControl", x => new { x.ControlId, x.RiskId });
                    table.ForeignKey(
                        name: "FK_RiskControl_Control_ControlId",
                        column: x => x.ControlId,
                        principalTable: "Control",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskControl_Risk_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Control_AutomationLevelId",
                table: "Control",
                column: "AutomationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Code",
                table: "Control",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Control_ControlStateId",
                table: "Control",
                column: "ControlStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Control_ControlTypeId",
                table: "Control",
                column: "ControlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Control_UserId",
                table: "Control",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_ControlledRiskId",
                table: "Risk",
                column: "ControlledRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_InherentRiskId",
                table: "Risk",
                column: "InherentRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_RiskCategoryId",
                table: "Risk",
                column: "RiskCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_UserId",
                table: "Risk",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskControl_RiskId",
                table: "RiskControl",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskImpact_ImpactTypeId",
                table: "RiskImpact",
                column: "ImpactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserControl_UserId",
                table: "UserControl",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskControl");

            migrationBuilder.DropTable(
                name: "UserControl");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Control");

            migrationBuilder.DropTable(
                name: "RiskImpact");

            migrationBuilder.DropTable(
                name: "MAutomationLevel");

            migrationBuilder.DropTable(
                name: "MControlState");

            migrationBuilder.DropTable(
                name: "MControlType");

            migrationBuilder.DropTable(
                name: "ImpactType");
        }
    }
}
