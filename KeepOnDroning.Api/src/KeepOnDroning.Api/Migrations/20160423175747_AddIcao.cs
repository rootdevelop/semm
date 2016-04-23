using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KeepOnDroning.Api.Migrations
{
    public partial class AddIcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icao",
                table: "Airports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Icao", table: "Airports");
        }
    }
}
