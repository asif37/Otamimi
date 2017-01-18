using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Otamimi.Migrations
{
    public partial class RequiredDocRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredDocumentId",
                table: "Requests",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequiredDocumentId",
                table: "Requests",
                column: "RequiredDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequiredDocuments_RequiredDocumentId",
                table: "Requests",
                column: "RequiredDocumentId",
                principalTable: "RequiredDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequiredDocuments_RequiredDocumentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequiredDocumentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequiredDocumentId",
                table: "Requests");
        }
    }
}
