using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class AddExpenseTypeIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("1131d46e-7865-49e6-8016-6e86927b1cc7"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("1c02667a-a957-428f-a82d-29ec1f3ef27c"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("20f39efe-5dbb-4890-baf6-eac8035d38fc"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("2e3728eb-1f4a-42d3-b9d9-ee06be18194f"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b5f8a03-8fb8-44bb-bba5-c1edaa32d5a8"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f1f9c31-ddf4-4188-8484-c63fbc44f897"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("63f61c36-4a68-4502-ba73-b70e1c8ed49b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6fa19252-ee8a-4adf-9812-c91c23af3dfe"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("92de237c-0a45-4515-b431-bf80f7b89ca7"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a577019e-7a06-4370-b38a-0d18d3e04aad"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e71abd2c-58f9-4fdd-b11f-7cc61d311ae3"));

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("02ee3adc-23f0-4b58-a2ce-b04c4b45a46c"), "fas fa-money-bill-wave", "Bills & Services" },
                    { new Guid("5bbe46e7-5bba-4106-8542-7ccf5ea2deba"), "fas fa-glass-cheers", "Entertainment" },
                    { new Guid("f02ed8c0-0e2f-40ec-8a1e-d76238aaf912"), "fas fa-bus-alt", "Transport" },
                    { new Guid("7d259015-f216-4f6e-89e9-524d72dfd0ae"), "fas fa-utensils", "Groceries" },
                    { new Guid("42038d52-b386-4d75-9de4-727b50c39b15"), "fas fa-home", "Home" },
                    { new Guid("ef24a264-8b0f-4b98-be71-154ef02dd69a"), "fas fa-pizza-slice", "Eating Out" },
                    { new Guid("501cc4aa-6643-4344-b51e-ca920fc2eab3"), "fas fa-users", "Family" },
                    { new Guid("b7dbd109-fa4f-4fbe-931f-83c5eb90b924"), "fas fa-money-check", "General" },
                    { new Guid("2fee3146-a43b-4029-ab9d-05961e766499"), "fas fa-heartbeat", "Lifestyle" },
                    { new Guid("fe648741-de4d-4588-8ef1-bff391e1b4d1"), "fas fa-shopping-basket", "Shopping" },
                    { new Guid("1f940484-dd20-4fc9-8f70-649812dfa491"), "fas fa-plane", "Holidays" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("02ee3adc-23f0-4b58-a2ce-b04c4b45a46c"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("1f940484-dd20-4fc9-8f70-649812dfa491"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("2fee3146-a43b-4029-ab9d-05961e766499"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("42038d52-b386-4d75-9de4-727b50c39b15"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("501cc4aa-6643-4344-b51e-ca920fc2eab3"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("5bbe46e7-5bba-4106-8542-7ccf5ea2deba"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("7d259015-f216-4f6e-89e9-524d72dfd0ae"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b7dbd109-fa4f-4fbe-931f-83c5eb90b924"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ef24a264-8b0f-4b98-be71-154ef02dd69a"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("f02ed8c0-0e2f-40ec-8a1e-d76238aaf912"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("fe648741-de4d-4588-8ef1-bff391e1b4d1"));

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("6fa19252-ee8a-4adf-9812-c91c23af3dfe"), null, "Bills & Services" },
                    { new Guid("3b5f8a03-8fb8-44bb-bba5-c1edaa32d5a8"), null, "Entertainment" },
                    { new Guid("e71abd2c-58f9-4fdd-b11f-7cc61d311ae3"), null, "Transport" },
                    { new Guid("2e3728eb-1f4a-42d3-b9d9-ee06be18194f"), null, "Groceries" },
                    { new Guid("63f61c36-4a68-4502-ba73-b70e1c8ed49b"), null, "Home" },
                    { new Guid("a577019e-7a06-4370-b38a-0d18d3e04aad"), null, "Eating Out" },
                    { new Guid("20f39efe-5dbb-4890-baf6-eac8035d38fc"), null, "Family" },
                    { new Guid("92de237c-0a45-4515-b431-bf80f7b89ca7"), null, "General" },
                    { new Guid("1131d46e-7865-49e6-8016-6e86927b1cc7"), null, "Lifestyle" },
                    { new Guid("4f1f9c31-ddf4-4188-8484-c63fbc44f897"), null, "Shopping" },
                    { new Guid("1c02667a-a957-428f-a82d-29ec1f3ef27c"), null, "Holidays" }
                });
        }
    }
}
