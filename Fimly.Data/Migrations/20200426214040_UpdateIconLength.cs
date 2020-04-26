using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class UpdateIconLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("390f37a0-1897-4895-b875-a2c6c7a1f2c8"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("3c23b4fb-657b-44d7-a26e-613460420d13"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("5d72d0c9-8910-4ed6-b3ec-6e4771a56544"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6cc67041-0bb8-4706-bdae-0a5d8659f4c8"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("7ade94e5-4627-47ff-afba-b8e11e71333e"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("886dac0a-e52a-4888-9519-ee8e8a5d0a86"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("994467a3-0918-4b27-b4e7-33f172d6cf0d"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("9d05caf1-da2c-44cc-9a75-33752991b1dd"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a4f44cf0-30d1-40b4-935f-6292b24417ce"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb1b39f1-cb61-48fe-a933-c53ec0f7ac4d"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb3dd454-9f3a-40eb-b76e-bb8232893d2e"));

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Expenses",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fb1b39f1-cb61-48fe-a933-c53ec0f7ac4d"), "Bills & Services" },
                    { new Guid("3c23b4fb-657b-44d7-a26e-613460420d13"), "Entertainment" },
                    { new Guid("a4f44cf0-30d1-40b4-935f-6292b24417ce"), "Transport" },
                    { new Guid("fb3dd454-9f3a-40eb-b76e-bb8232893d2e"), "Groceries" },
                    { new Guid("9d05caf1-da2c-44cc-9a75-33752991b1dd"), "Home" },
                    { new Guid("994467a3-0918-4b27-b4e7-33f172d6cf0d"), "Eating Out" },
                    { new Guid("5d72d0c9-8910-4ed6-b3ec-6e4771a56544"), "Family" },
                    { new Guid("7ade94e5-4627-47ff-afba-b8e11e71333e"), "General" },
                    { new Guid("886dac0a-e52a-4888-9519-ee8e8a5d0a86"), "Lifestyle" },
                    { new Guid("6cc67041-0bb8-4706-bdae-0a5d8659f4c8"), "Shopping" },
                    { new Guid("390f37a0-1897-4895-b875-a2c6c7a1f2c8"), "Holidays" }
                });
        }
    }
}
