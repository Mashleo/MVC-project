using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Diplom_project.Migrations
{
    public partial class initial29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId1",
                table: "Logbooks",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarId2",
                table: "Logbooks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Logbooks_CarId1",
                table: "Logbooks",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Logbooks_Cars_CarId1",
                table: "Logbooks",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logbooks_Cars_CarId1",
                table: "Logbooks");

            migrationBuilder.DropIndex(
                name: "IX_Logbooks_CarId1",
                table: "Logbooks");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Logbooks");

            migrationBuilder.DropColumn(
                name: "CarId2",
                table: "Logbooks");
        }
    }
}
