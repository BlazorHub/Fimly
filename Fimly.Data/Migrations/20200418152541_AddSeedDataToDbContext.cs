using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class AddSeedDataToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "GBP", "£" },
                    { 2, "EUR", "€" },
                    { 3, "USD", "$" },
                    { 4, "JPY", "¥" },
                    { 5, "KRW", "₩" },
                    { 6, "SAR", "﷼" },
                    { 7, "RUB", "₽" },
                    { 8, "ZAR", "R" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9e5c02bd-967c-43e4-98f8-7b26c1703951"), "Lifestyle" },
                    { new Guid("acc1f8f2-8494-4b58-9e5f-6ba31b4a333c"), "General" },
                    { new Guid("d4a9ce3f-6492-41fd-a166-58e3f50a5f56"), "Family" },
                    { new Guid("911d21d9-00a6-4296-ba5d-9bf2b93d4881"), "Eating Out" },
                    { new Guid("c8ed231c-f712-46af-a5cd-2df3a6c25439"), "Entertainment" },
                    { new Guid("e2ea119f-e312-4f93-88ad-9d9c404c8d25"), "Groceries" },
                    { new Guid("ed70f89a-0c4f-43af-ae56-841bf68bb90d"), "Transport" },
                    { new Guid("13da399c-6a9b-4ca6-87b4-3f1c2378de91"), "Shopping" },
                    { new Guid("6fd1aa9a-2fc4-445b-b41a-747e4a0d7d4e"), "Bills & Services" },
                    { new Guid("ab993559-3226-46a7-9e5e-9e3617b09c20"), "Home" },
                    { new Guid("6a1c2d39-55f0-4bf8-bd58-4eefdd5e279c"), "Holidays" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("13da399c-6a9b-4ca6-87b4-3f1c2378de91"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6a1c2d39-55f0-4bf8-bd58-4eefdd5e279c"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6fd1aa9a-2fc4-445b-b41a-747e4a0d7d4e"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("911d21d9-00a6-4296-ba5d-9bf2b93d4881"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("9e5c02bd-967c-43e4-98f8-7b26c1703951"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ab993559-3226-46a7-9e5e-9e3617b09c20"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("acc1f8f2-8494-4b58-9e5f-6ba31b4a333c"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("c8ed231c-f712-46af-a5cd-2df3a6c25439"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("d4a9ce3f-6492-41fd-a166-58e3f50a5f56"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e2ea119f-e312-4f93-88ad-9d9c404c8d25"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ed70f89a-0c4f-43af-ae56-841bf68bb90d"));
        }
    }
}
