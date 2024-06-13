using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Email", "RoomId" },
                values: new object[] { new Guid("34a24c2b-d3e8-41a1-b3ed-b9a5e59aae47"), "Sara", "Brandão", "saralimabrandao@outlook.com", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("34a24c2b-d3e8-41a1-b3ed-b9a5e59aae47"));
        }
    }
}
