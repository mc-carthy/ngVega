using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Audi')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('BMW')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mercedes')");

            // The below code is inefficient, we should query the database for each MakeID once and store it in a variable.
            // Because we have such a small number of recurds, it's fine.

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A3', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A5', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A6', (SELECT ID FROM Makes WHERE Name = 'Audi'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('1-Series', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('3-Series', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('5-Series', (SELECT ID FROM Makes WHERE Name = 'BMW'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('A-Class', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('C-Class', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) VALUES ('E-Class', (SELECT ID FROM Makes WHERE Name = 'Mercedes'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Audi', 'BMW', 'Mercedes')");
        }
    }
}
