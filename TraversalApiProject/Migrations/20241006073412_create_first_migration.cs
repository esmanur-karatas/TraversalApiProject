﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApiProject.Migrations
{
    /// <inheritdoc />
    public partial class create_first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
