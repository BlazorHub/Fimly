using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fimly.Data.Migrations
{
    public partial class AddSharedPersonDataSeeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0f983319-e8de-4db6-bb96-4aedf988e543"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("451c7750-44ad-4bfa-9703-6a87a0e915c5"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("45e6658d-3485-4e6f-8ab6-75715daffc15"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("632f2426-b4c7-4f86-8e3e-cdd2576c64cc"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("65cca374-9d2c-4139-a4ee-daa19a6a6ca9"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("66cdb77b-3a4f-4741-9935-1b434f333839"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("90db6e6e-bb1a-4784-b6fd-e378b6be6885"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("9d4f2eb3-2c32-4e8f-8487-e7764efe3acb"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a41ddee7-6395-41fc-8cec-4dc8c0b832bd"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e8679c34-17a1-4237-ac58-5cd41a19245b"));

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e8d751ee-3c3e-4432-8a38-2ddaec09a2eb"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("e8d751ee-3c3e-4432-8a38-2ddaec09a2eb"), "Bills & Services" },
                    { new Guid("0f983319-e8de-4db6-bb96-4aedf988e543"), "Entertainment" },
                    { new Guid("e8679c34-17a1-4237-ac58-5cd41a19245b"), "Transport" },
                    { new Guid("66cdb77b-3a4f-4741-9935-1b434f333839"), "Groceries" },
                    { new Guid("a41ddee7-6395-41fc-8cec-4dc8c0b832bd"), "Home" },
                    { new Guid("9d4f2eb3-2c32-4e8f-8487-e7764efe3acb"), "Eating Out" },
                    { new Guid("65cca374-9d2c-4139-a4ee-daa19a6a6ca9"), "Family" },
                    { new Guid("632f2426-b4c7-4f86-8e3e-cdd2576c64cc"), "General" },
                    { new Guid("451c7750-44ad-4bfa-9703-6a87a0e915c5"), "Lifestyle" },
                    { new Guid("45e6658d-3485-4e6f-8ab6-75715daffc15"), "Shopping" },
                    { new Guid("90db6e6e-bb1a-4784-b6fd-e378b6be6885"), "Holidays" }
                });
        }
    }
}
