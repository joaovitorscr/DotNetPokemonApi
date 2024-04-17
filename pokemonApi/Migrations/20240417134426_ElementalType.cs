using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokemonApi.Migrations
{
    /// <inheritdoc />
    public partial class ElementalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementalType",
                table: "Pokemons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemons",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ElementalType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Element = table.Column<string>(type: "TEXT", nullable: false),
                    Strength = table.Column<string>(type: "TEXT", nullable: false),
                    Weakness = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementalType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementalType_Pokemons_Id",
                        column: x => x.Id,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementalType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pokemons",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ElementalType",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);
        }
    }
}
