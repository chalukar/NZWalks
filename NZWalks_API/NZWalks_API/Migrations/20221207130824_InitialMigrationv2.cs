using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks_API.Migrations
{
    public partial class InitialMigrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_MyProperty_WalkDifficaltyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "WalkDifficalty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalkDifficalty",
                table: "WalkDifficalty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficalty_WalkDifficaltyId",
                table: "Walks",
                column: "WalkDifficaltyId",
                principalTable: "WalkDifficalty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficalty_WalkDifficaltyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalkDifficalty",
                table: "WalkDifficalty");

            migrationBuilder.RenameTable(
                name: "WalkDifficalty",
                newName: "MyProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_MyProperty_WalkDifficaltyId",
                table: "Walks",
                column: "WalkDifficaltyId",
                principalTable: "MyProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
