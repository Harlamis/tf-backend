using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trackfinder.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedBestiary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Ac", "BaseName", "DetailsJson", "MaxHp" },
                values: new object[,]
                {
                    { "dragon-001", 19, "Ancient Dragon", "{\r\n  \"level\": 12,\r\n  \"traits\": [\"Dragon\", \"Fire\"],\r\n  \"speed\": {\r\n    \"walking\": 30,\r\n    \"flying\": 100,\r\n    \"swimming\": 0,\r\n    \"burrowing\": 0,\r\n    \"climbing\": 0\r\n  },\r\n  \"savingThrows\": {\r\n    \"fortitude\": 24,\r\n    \"reflex\": 20,\r\n    \"will\": 22\r\n  },\r\n  \"attacks\": [\r\n    { \"name\": \"Bite\", \"type\": \"melee\", \"bonus\": 26, \"traits\": [\"reach\"] },\r\n    { \"name\": \"Fire Breath\", \"type\": \"ranged\", \"bonus\": 20, \"traits\": [\"magical\", \"fire\"] }\r\n  ],\r\n  \"loot\": [\r\n    { \"item\": \"Dragon Scales\", \"quantity\": 5 },\r\n    { \"item\": \"Dragon Bone\", \"quantity\": 3 }\r\n  ]\r\n}", 250 },
                    { "draugr-001", 15, "Draugr Deathlord", "{\r\n  \"level\": 5,\r\n  \"traits\": [\"Undead\", \"Mindless\"],\r\n  \"speed\": {\r\n    \"walking\": 25,\r\n    \"flying\": 0,\r\n    \"swimming\": 0,\r\n    \"burrowing\": 0,\r\n    \"climbing\": 0\r\n  },\r\n  \"savingThrows\": {\r\n    \"fortitude\": 12,\r\n    \"reflex\": 8,\r\n    \"will\": 10\r\n  },\r\n  \"attacks\": [\r\n    { \"name\": \"Ebony Greatsword\", \"type\": \"melee\", \"bonus\": 14, \"traits\": [\"reach\", \"sweep\"] }\r\n  ],\r\n  \"loot\": [\r\n    { \"item\": \"Bone Meal\", \"quantity\": 2 },\r\n    { \"item\": \"Ebony Greatsword\", \"quantity\": 1 }\r\n  ]\r\n}", 85 },
                    { "mudcrab-001", 12, "Mudcrab", "{\r\n  \"level\": 1,\r\n  \"traits\": [\"Beast\", \"Aquatic\"],\r\n  \"speed\": {\r\n    \"walking\": 20,\r\n    \"flying\": 0,\r\n    \"swimming\": 20,\r\n    \"burrowing\": 10,\r\n    \"climbing\": 0\r\n  },\r\n  \"savingThrows\": {\r\n    \"fortitude\": 6,\r\n    \"reflex\": 4,\r\n    \"will\": 2\r\n  },\r\n  \"attacks\": [\r\n    { \"name\": \"Pincer\", \"type\": \"melee\", \"bonus\": 6, \"traits\": [\"agile\", \"finesse\"] }\r\n  ],\r\n  \"loot\": [\r\n    { \"item\": \"Mudcrab Chitin\", \"quantity\": 1 }\r\n  ]\r\n}", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: "dragon-001");

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: "draugr-001");

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: "mudcrab-001");
        }
    }
}
