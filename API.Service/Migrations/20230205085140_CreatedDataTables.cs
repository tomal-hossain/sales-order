using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Service.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDataTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Windows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    WindowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubElements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_Id",
                table: "SubElements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_WindowId",
                table: "SubElements",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_Id",
                table: "Windows",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
