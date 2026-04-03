using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TH_502045_1.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Routes",
				columns: table => new
				{
					RouteId = table
						.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DestinationName = table.Column<string>(
						type: "nvarchar(max)",
						nullable: false
					),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					IsActive = table.Column<bool>(type: "bit", nullable: false),
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Routes", x => x.RouteId);
				}
			);

			migrationBuilder.CreateTable(
				name: "TicketOrders",
				columns: table => new
				{
					TicketOrderId = table
						.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RouteId = table.Column<int>(type: "int", nullable: true),
					PurchaseDate = table.Column<DateTime>(
						type: "datetime2",
						nullable: false
					),
					PaymentMethod = table.Column<string>(
						type: "nvarchar(max)",
						nullable: false
					),
					TotalAmount = table.Column<decimal>(
						type: "decimal(18,2)",
						nullable: false
					),
					isTransferred = table.Column<short>(type: "smallint", nullable: true),
					BarcodeData = table.Column<string>(
						type: "nvarchar(max)",
						nullable: true
					),
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TicketOrders", x => x.TicketOrderId);
					table.ForeignKey(
						name: "FK_TicketOrders_Routes_RouteId",
						column: x => x.RouteId,
						principalTable: "Routes",
						principalColumn: "RouteId"
					);
				}
			);

			migrationBuilder.InsertData(
				table: "Routes",
				columns: new[] { "RouteId", "DestinationName", "IsActive", "Price" },
				values: new object[,]
				{
					{ 1, "Ga Bến Thành", true, 15000m },
					{ 2, "Ga Nhà hát Thành phố", true, 15000m },
					{ 3, "Ga Ba Son", true, 15000m },
					{ 4, "Ga Tân Cảng", true, 20000m },
					{ 5, "Ga Suối Tiên", true, 25000m },
				}
			);

			migrationBuilder.CreateIndex(
				name: "IX_TicketOrders_RouteId",
				table: "TicketOrders",
				column: "RouteId"
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(name: "TicketOrders");

			migrationBuilder.DropTable(name: "Routes");
		}
	}
}
