using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackfinder.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenamemaxHptoMaxHpInMonsterTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxHp",
                table: "Templates",
                newName: "MaxHp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxHp",
                table: "Templates",
                newName: "maxHp");
        }
    }
}
