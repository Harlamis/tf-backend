using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackfinder.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMonsterStatsAndTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CombatMonsters_MonsterTemplate_TemplateId",
                table: "CombatMonsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterTemplate",
                table: "MonsterTemplate");

            migrationBuilder.RenameTable(
                name: "MonsterTemplate",
                newName: "Templates");

            migrationBuilder.RenameColumn(
                name: "ActiveEncounterId",
                table: "Encounters",
                newName: "ActiveMonsterId");

            migrationBuilder.AddColumn<int>(
                name: "Ac",
                table: "CombatMonsters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlayer",
                table: "CombatMonsters",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxHp",
                table: "CombatMonsters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CombatMonsters",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Templates",
                table: "Templates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CombatMonsters_Templates_TemplateId",
                table: "CombatMonsters",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CombatMonsters_Templates_TemplateId",
                table: "CombatMonsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Templates",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Ac",
                table: "CombatMonsters");

            migrationBuilder.DropColumn(
                name: "IsPlayer",
                table: "CombatMonsters");

            migrationBuilder.DropColumn(
                name: "MaxHp",
                table: "CombatMonsters");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CombatMonsters");

            migrationBuilder.RenameTable(
                name: "Templates",
                newName: "MonsterTemplate");

            migrationBuilder.RenameColumn(
                name: "ActiveMonsterId",
                table: "Encounters",
                newName: "ActiveEncounterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterTemplate",
                table: "MonsterTemplate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CombatMonsters_MonsterTemplate_TemplateId",
                table: "CombatMonsters",
                column: "TemplateId",
                principalTable: "MonsterTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
