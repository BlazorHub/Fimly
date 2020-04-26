using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class AddIconStringToExpenseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0ea37fd8-d78f-42d9-86d0-33866600def3"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("2e422edb-081e-4d73-8479-fbae390d296c"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("412fc77e-cd38-4a55-85d6-713abed5547b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("4492e34d-39a3-40de-95be-1d379c2b03bd"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("502b08f4-9f76-4a27-9749-1a6cc9fe8b5b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("621188a9-2ba1-447c-8fc4-c0f39b4043ca"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("7dcb2af3-defe-4a81-ab40-13367121b470"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a1bdae84-eb27-420f-a84b-cb4c8cc6b747"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ab3ae1b6-45c6-43dd-8d24-acddfd785827"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ebd8cd85-bfee-4582-ac12-12911dccf6cb"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ffdf1d05-f040-4fad-8ea4-ede7568aa2bb"));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Expenses",
                maxLength: 20,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Expenses");

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("502b08f4-9f76-4a27-9749-1a6cc9fe8b5b"), "Bills & Services" },
                    { new Guid("0ea37fd8-d78f-42d9-86d0-33866600def3"), "Entertainment" },
                    { new Guid("412fc77e-cd38-4a55-85d6-713abed5547b"), "Transport" },
                    { new Guid("4492e34d-39a3-40de-95be-1d379c2b03bd"), "Groceries" },
                    { new Guid("ab3ae1b6-45c6-43dd-8d24-acddfd785827"), "Home" },
                    { new Guid("ebd8cd85-bfee-4582-ac12-12911dccf6cb"), "Eating Out" },
                    { new Guid("a1bdae84-eb27-420f-a84b-cb4c8cc6b747"), "Family" },
                    { new Guid("ffdf1d05-f040-4fad-8ea4-ede7568aa2bb"), "General" },
                    { new Guid("7dcb2af3-defe-4a81-ab40-13367121b470"), "Lifestyle" },
                    { new Guid("2e422edb-081e-4d73-8479-fbae390d296c"), "Shopping" },
                    { new Guid("621188a9-2ba1-447c-8fc4-c0f39b4043ca"), "Holidays" }
                });
        }
    }
}
