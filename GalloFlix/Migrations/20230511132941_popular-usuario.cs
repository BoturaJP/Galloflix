using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalloFlix.Migrations
{
    public partial class popularusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96906a09-06ad-42b5-afde-5c5db34f3db9", "a7c5647a-2b22-4526-909d-cac747b782c4", "Moderador", "MODERADOR" },
                    { "af22d4b5-cafb-4ed6-a35c-89a33fb74153", "9529c500-f66a-4128-9de6-1b79ca92ca3a", "Usuário", "USUÁRIO" },
                    { "b3c009ee-9585-4f2d-8ca9-e8b1136ff973", "bf338b48-f14c-43cb-a156-89819177901c", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41ec9a71-8d2c-4462-85eb-e3f3ad35adf5", 0, "bfa2cded-a341-4e5d-9fe2-425231674df4", new DateTime(2006, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "AppUser", "rafinhabotura@gmail.com", true, false, null, "Rafael Botura", "RAFINHABOTURA@GMAIL.COM", "BOTATUDO", "AQAAAAEAACcQAAAAEGbE19gVjzFioMBNFe2i8m3S56LknqjVkC6LN1GWZ7jbsQTUbXrp74KnmTrgAxgLlQ==", "14981357504", true, "/img/users/avatar.png", "5bccee54-c208-43ed-8940-ebe5a8bf3756", false, "BotaTudo" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3c009ee-9585-4f2d-8ca9-e8b1136ff973", "41ec9a71-8d2c-4462-85eb-e3f3ad35adf5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "96906a09-06ad-42b5-afde-5c5db34f3db9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "af22d4b5-cafb-4ed6-a35c-89a33fb74153");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3c009ee-9585-4f2d-8ca9-e8b1136ff973", "41ec9a71-8d2c-4462-85eb-e3f3ad35adf5" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b3c009ee-9585-4f2d-8ca9-e8b1136ff973");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "41ec9a71-8d2c-4462-85eb-e3f3ad35adf5");
        }
    }
}
