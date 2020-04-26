using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class AddIconStringToExpenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b3a3996-fe46-43e1-b279-99ef11544cc9"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("352fe506-e7e2-4a05-966a-7494dfdd6dc8"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("4f75952a-b550-45bd-b7c4-32713585c3d8"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("8afa7835-1ebb-4bbb-a0a1-f1ab3962883f"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("8b2b3b73-b2fb-4c9e-93ca-c004a1a8dee4"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("94c8bf83-0921-4e73-9d47-e75784002c05"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a9143be6-e0a1-451f-b5f6-0887b6e316d6"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b5c3bfa4-bf1c-4052-8ca3-f3e6e457eb4a"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb668287-3c92-4901-9fde-7615a3108e5f"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e29f9ef4-0123-469b-a180-119c9c567790"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1beaaab-af0b-42d3-8d1c-521da5b85760"));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ExpenseTypes",
                maxLength: 50,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ExpenseTypes");

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a9143be6-e0a1-451f-b5f6-0887b6e316d6"), "Bills & Services" },
                    { new Guid("8b2b3b73-b2fb-4c9e-93ca-c004a1a8dee4"), "Entertainment" },
                    { new Guid("8afa7835-1ebb-4bbb-a0a1-f1ab3962883f"), "Transport" },
                    { new Guid("f1beaaab-af0b-42d3-8d1c-521da5b85760"), "Groceries" },
                    { new Guid("4f75952a-b550-45bd-b7c4-32713585c3d8"), "Home" },
                    { new Guid("1b3a3996-fe46-43e1-b279-99ef11544cc9"), "Eating Out" },
                    { new Guid("b5c3bfa4-bf1c-4052-8ca3-f3e6e457eb4a"), "Family" },
                    { new Guid("352fe506-e7e2-4a05-966a-7494dfdd6dc8"), "General" },
                    { new Guid("cb668287-3c92-4901-9fde-7615a3108e5f"), "Lifestyle" },
                    { new Guid("e29f9ef4-0123-469b-a180-119c9c567790"), "Shopping" },
                    { new Guid("94c8bf83-0921-4e73-9d47-e75784002c05"), "Holidays" }
                });
        }
    }
}
