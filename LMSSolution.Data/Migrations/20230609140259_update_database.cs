using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSSolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e029d545-0a04-4088-b156-0f1afa8ef68b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "officer", "officer" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92abd6c9-6122-4422-9dce-a4548c7c2bf1", "AQAAAAIAAYagAAAAEEBILFTKBqgpa7L7JFSSmAr9rkSG7hls18fnCrH0lvUvpXI3sFj0wsjfHXCsMFvA5Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e029d545-0a04-4088-b156-0f1afa8ef68b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "ministry", "ministry" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7d6ae65-8029-46c5-a006-f89d6d04fa8c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d75b7e4-1e35-46c6-a490-2ed67749a303", "AQAAAAIAAYagAAAAEDLXl+cS74O8cbfIqK/P9KzHC0faP/59ItunudGPA1FpVkUuFARn+8QpM5u0dmsMeQ==" });
        }
    }
}
