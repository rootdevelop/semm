using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace KeepOnDroning.Api.Migrations
{
    public partial class AddOoi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oois",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentLat = table.Column<double>(nullable: false),
                    CurrentLng = table.Column<double>(nullable: false),
                    DestinationLat = table.Column<double>(nullable: false),
                    DestinationLng = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Speed = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UniqueIdentifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ooi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Oois");
        }
    }
}
