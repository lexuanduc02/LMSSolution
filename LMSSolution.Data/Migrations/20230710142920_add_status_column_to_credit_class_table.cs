using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_status_column_to_credit_class_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CreditClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f40d63af-55a1-40e5-8908-bcbc4cc2bea3", "AQAAAAIAAYagAAAAELzy/6qtjbVVo5cVVWkzYLWVIFbHA7iOy3nDPhxqCHF5H9Q5VOFyeFWJHlZEpkFcSg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CreditClasses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5663712f-8f4e-4aa6-b7c7-e8b1c6346492", "AQAAAAIAAYagAAAAEPdEUHsvMPuRt+PEzLQqwhfn742OzBEKdm0Qq632DtVdZ+05dtRhH61TFKBPt0xk7w==" });
        }
    }
}
