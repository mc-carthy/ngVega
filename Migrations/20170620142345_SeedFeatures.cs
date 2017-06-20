using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Heated Seats')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Sequential Gearbox')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Cruise Control')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Heated Seats', 'Sequential Gearbox', 'Cruise Control')");
        }
    }
}
