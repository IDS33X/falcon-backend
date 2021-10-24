using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class LastUpdatedDateTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Trigger
            migrationBuilder.Sql(

                @"create trigger [dbo].[Control_Update] on [dbo].[Control]
                     AFTER UPDATE
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;

                            DECLARE @Id UNIQUEIDENTIFIER

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

        }
    }
}
