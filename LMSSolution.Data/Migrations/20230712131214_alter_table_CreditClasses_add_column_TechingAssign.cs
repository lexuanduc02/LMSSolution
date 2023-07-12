using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_CreditClasses_add_column_TechingAssign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeachingAssign",
                table: "CreditClasses",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7395f0e-439a-4dc6-a147-58eef1fbe521", "AQAAAAIAAYagAAAAEHCCq7K9/as+/WivfZYF4t+1ndp+4/ZpfnlBUDfqHP4A1+mWJC6GK7HRU4xVdAkPYg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachingAssign",
                table: "CreditClasses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f40d63af-55a1-40e5-8908-bcbc4cc2bea3", "AQAAAAIAAYagAAAAELzy/6qtjbVVo5cVVWkzYLWVIFbHA7iOy3nDPhxqCHF5H9Q5VOFyeFWJHlZEpkFcSg==" });
        }
    }
}
