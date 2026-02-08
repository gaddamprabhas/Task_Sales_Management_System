using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSales.Infrastructure.Migrations
{
    public partial class AddTaskStatusAndPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---- DROP FK SAFELY ----
            migrationBuilder.Sql(@"
DECLARE @fkName nvarchar(200);
SELECT @fkName = fk.name
FROM sys.foreign_keys fk
WHERE fk.parent_object_id = OBJECT_ID('Tasks');

IF @fkName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE Tasks DROP CONSTRAINT ' + @fkName);
END
");

            // ---- DROP INDEX SAFELY ----
            migrationBuilder.Sql(@"
IF EXISTS (
    SELECT 1 
    FROM sys.indexes 
    WHERE name = 'IX_Tasks_EmployeeId'
      AND object_id = OBJECT_ID('Tasks')
)
BEGIN
    DROP INDEX IX_Tasks_EmployeeId ON Tasks;
END
");

            // ---- DROP COLUMN ----
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Tasks");

            // ---- ADD PRIORITY ----
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
