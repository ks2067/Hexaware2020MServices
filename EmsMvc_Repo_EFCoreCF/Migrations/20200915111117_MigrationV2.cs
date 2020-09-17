using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmsMvc_Repo_EFCoreCF.Migrations
{
    public partial class MigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Email", "Gender", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "param@hexaware.com", 2, "Param", 9988990098L },
                    { 2, new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "shona@hexaware.com", 1, "Shona", 9988990098L }
                });
        }
    }
}
