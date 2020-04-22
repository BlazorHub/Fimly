using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class RemoveSharedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("22cdf1bb-d626-4bb6-bfbf-d515d4a1214a"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("2b571586-feac-4641-b494-544157a6a0f5"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6343a093-c98a-4db3-8af5-4e9407600b02"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6efac255-c9c4-4140-9007-82e7fabc5d52"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("8298b104-24c3-4be9-83e5-7645d467a57b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b4fd3454-312c-4d7b-b07f-d073d89da1e2"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b936cdb6-5130-4e18-9499-8236715aef6b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb97c20c-5a8c-4bd0-83db-a67d88b7b2ee"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc3519ce-0df7-4e8e-adff-808f84d04bb5"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("f2d059b3-8924-4c8a-9a45-cdce56c2bf81"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("f33827d3-1f34-4984-bf30-6d5060b861a6"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("10280c94-c89f-4fe7-8820-839b0f5db42a"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8298b104-24c3-4be9-83e5-7645d467a57b"), "Bills & Services" },
                    { new Guid("b936cdb6-5130-4e18-9499-8236715aef6b"), "Entertainment" },
                    { new Guid("b4fd3454-312c-4d7b-b07f-d073d89da1e2"), "Transport" },
                    { new Guid("22cdf1bb-d626-4bb6-bfbf-d515d4a1214a"), "Groceries" },
                    { new Guid("2b571586-feac-4641-b494-544157a6a0f5"), "Home" },
                    { new Guid("6efac255-c9c4-4140-9007-82e7fabc5d52"), "Eating Out" },
                    { new Guid("f33827d3-1f34-4984-bf30-6d5060b861a6"), "Family" },
                    { new Guid("f2d059b3-8924-4c8a-9a45-cdce56c2bf81"), "General" },
                    { new Guid("6343a093-c98a-4db3-8af5-4e9407600b02"), "Lifestyle" },
                    { new Guid("cb97c20c-5a8c-4bd0-83db-a67d88b7b2ee"), "Shopping" },
                    { new Guid("cc3519ce-0df7-4e8e-adff-808f84d04bb5"), "Holidays" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Income", "IsSharedPerson", "Name", "UserId" },
                values: new object[] { new Guid("10280c94-c89f-4fe7-8820-839b0f5db42a"), 0m, true, "Shared", null });
        }
    }
}
