using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marvin.IDP.Migrations
{
    public partial class AddingUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0786ad36-7a60-484a-9dd4-f17342dc02e1"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("26e31fe1-3bc8-488e-aa0f-9067782f71ab"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2f7fc90c-9b9b-45d5-8bdf-d4e29e2b454a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("53be613a-b495-4ef3-8549-10e879d2d06a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("991644f5-93e8-4185-bf56-efa2fdda7b85"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("9af868e4-b0b5-4f59-bf6c-d5e4b0bd357f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b7fb94bb-ab8a-41c4-aa02-595c1215938b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c398875b-49e1-41d3-88ea-872199c8f435"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("daf7f0f4-8811-4451-b9c8-ed86d5062f06"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("f2890495-8e14-4967-a5a3-7a38a2555dcf"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("9af868e4-b0b5-4f59-bf6c-d5e4b0bd357f"), "af1e924d-7bee-403c-bfce-e9d2f27a7f71", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("2f7fc90c-9b9b-45d5-8bdf-d4e29e2b454a"), "7e87e4f3-abc6-491f-82df-c5feac1b9d58", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("0786ad36-7a60-484a-9dd4-f17342dc02e1"), "57db31b0-8ecf-46e4-b996-3cbf8f1bce83", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("daf7f0f4-8811-4451-b9c8-ed86d5062f06"), "ff2f752d-bec1-400c-a68d-1055562134bb", "subscriptionlevel", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("26e31fe1-3bc8-488e-aa0f-9067782f71ab"), "dcfd0e45-d27a-4717-a271-b0c14db9e7b4", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("f2890495-8e14-4967-a5a3-7a38a2555dcf"), "5a034467-be14-49d0-9f6a-671333539b41", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("b7fb94bb-ab8a-41c4-aa02-595c1215938b"), "73f02060-d43e-42f9-8195-63db6f334593", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("c398875b-49e1-41d3-88ea-872199c8f435"), "8f833904-26fe-4ffa-a96e-8347a69d4dc6", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("991644f5-93e8-4185-bf56-efa2fdda7b85"), "adc6de2b-5d6d-43f3-b53b-4d650a93cba9", "subscriptionlevel", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("53be613a-b495-4ef3-8549-10e879d2d06a"), "9ea3d865-bda8-4342-8ed4-135dcf8f9cae", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "910fb737-cee5-45f0-903e-c6d877712765");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "6b796a9d-2fbf-4185-8508-3f186df39f61");
        }
    }
}
