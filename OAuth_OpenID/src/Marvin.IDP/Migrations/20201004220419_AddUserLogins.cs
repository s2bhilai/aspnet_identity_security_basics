using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvin.IDP.Migrations
{
    public partial class AddUserLogins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("020c138d-b832-4554-bf35-fa1b12f603ec"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2265056e-618c-4714-8aca-ac4c97d0414c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5aff4a48-b5e4-4186-b5be-c67ca5084574"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5e3258ab-3f6f-4fa8-99fe-00fca4b68471"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6d88c5eb-e259-4f62-a674-9ab3acfb964d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7225d09b-8c48-4956-85e8-f165c9fac0a8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("98c080b7-93b3-4c57-83a0-64f59a25ca1e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9eb430d6-3861-43d9-a54b-77973c4c5ca6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("dd088eed-df8e-46dd-a95a-c8836289687e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f399c005-c9f8-4b90-bab1-c9687370fa2d"));

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("18936ffc-90de-42b5-a7a0-f144bdd78ece"), "641eec35-a88f-44c8-a576-8ce134e1d5aa", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("281b1681-a9de-4c14-a71f-b5872c80b194"), "f7906f79-6eed-46a7-aa62-6525f7ee4e51", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("103dd6fd-fb9d-4542-8ee5-b344f3715369"), "32a79eb6-498f-4889-afd0-989a004d0b4e", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("4ee291eb-c05d-4f4b-bcb1-8a8b998ae6fb"), "d42d8b89-5c72-48b4-bc09-2bc0fdddaf59", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("e40c21f3-9d5d-4c82-82f4-9e5fdea19652"), "f0cf09ca-070a-4a20-a9db-e9e1d99bc17c", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "frank@someprovider.com" },
                    { new Guid("58227d0e-ecea-4d06-be61-b81690e0dcca"), "003dcffb-422d-4416-bbcf-57440cf50368", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("3b24a112-6a0f-4fc2-b54b-b4a45f94cdaa"), "3fa9bc19-56a4-45a1-a404-afd79fafa073", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("73a139dc-02aa-41e8-9e27-9b4084d50368"), "76c1a72a-0f95-48ff-8a9f-6fe4f255ff44", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("d6834c72-bbe8-4a14-88dd-aaddb3aa7403"), "17232a88-99af-4acd-a3cb-74adc832495c", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "claire@someprovider.com" },
                    { new Guid("d6b33196-178e-4924-ad4b-c18de73db55c"), "03f1621b-3bc7-42d6-b680-1231601af175", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "2696da76-8947-48fe-9283-971fa953b41c");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "18c217ac-4c69-4d0f-93db-31776f342d66");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("103dd6fd-fb9d-4542-8ee5-b344f3715369"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("18936ffc-90de-42b5-a7a0-f144bdd78ece"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("281b1681-a9de-4c14-a71f-b5872c80b194"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("3b24a112-6a0f-4fc2-b54b-b4a45f94cdaa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4ee291eb-c05d-4f4b-bcb1-8a8b998ae6fb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("58227d0e-ecea-4d06-be61-b81690e0dcca"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("73a139dc-02aa-41e8-9e27-9b4084d50368"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d6834c72-bbe8-4a14-88dd-aaddb3aa7403"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d6b33196-178e-4924-ad4b-c18de73db55c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e40c21f3-9d5d-4c82-82f4-9e5fdea19652"));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("7225d09b-8c48-4956-85e8-f165c9fac0a8"), "a4d386d1-3133-427e-a5a3-18b68b71d2e5", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("9eb430d6-3861-43d9-a54b-77973c4c5ca6"), "d573a80f-6541-4317-aac8-e7f415a0f6b8", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("020c138d-b832-4554-bf35-fa1b12f603ec"), "a085f402-613f-4261-8429-98966e2e8544", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("98c080b7-93b3-4c57-83a0-64f59a25ca1e"), "a8aaca1b-b4f3-4d2e-a77d-f8e30d8c3f8d", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("dd088eed-df8e-46dd-a95a-c8836289687e"), "40ffc593-7b4c-40e5-b927-d344209d0f69", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "frank@someprovider.com" },
                    { new Guid("6d88c5eb-e259-4f62-a674-9ab3acfb964d"), "6cf1d7e6-ecb6-4d0d-8098-6555ddf37a3a", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("5e3258ab-3f6f-4fa8-99fe-00fca4b68471"), "bd775b30-da9f-4e41-81f5-990e350e47b9", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("2265056e-618c-4714-8aca-ac4c97d0414c"), "456dde60-7ce7-4469-88c6-2ad3735c1770", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("5aff4a48-b5e4-4186-b5be-c67ca5084574"), "1e7a2849-20d9-43e1-b7d9-c4fb046ae3c4", "email", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "claire@someprovider.com" },
                    { new Guid("f399c005-c9f8-4b90-bab1-c9687370fa2d"), "e24e1864-c4c8-4c69-8c8a-9a481c4faa79", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "b0c294cf-9304-4b19-a7af-f1ae60b90674");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "1a5c64b9-671b-4774-b9a2-5569bd4e9a9f");
        }
    }
}
