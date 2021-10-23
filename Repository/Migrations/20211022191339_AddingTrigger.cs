using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddingTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Control",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            //Trigger
            migrationBuilder.Sql(

                @"create trigger [dbo].[Control_Update] on [dbo].[Control]
                     AFTER UPDATE
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                            DECLARE @Id INT

                            SELECT @Id = INSERTED.Id
                            FROM INSERTED

                            UPDATE dbo.Control
                            SET LastUpdateDate = getdate()
                            WHERE Id = @Id
                        END"

                );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Control",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
