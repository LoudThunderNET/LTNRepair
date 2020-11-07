using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    IsNode = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "SparePart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IsNode = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePart", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SparePart_SparePart__ParentId",
                        column: x => x.ParentId,
                        principalTable: "SparePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Inn = table.Column<string>(unicode: false, maxLength: 22, nullable: true),
                    Kpp = table.Column<string>(unicode: false, maxLength: 9, nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    MiddleName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 22, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Client_ClientType__ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    ClientId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    DefectDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    ExternalStateDescription = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    DiagnosticResult = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Complectation = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    RepairCost = table.Column<decimal>(type: "decimal(18,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Order_Client__ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Equipment__EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus__StatusId",
                        column: x => x.StatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    SparePartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Charges = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOrderItem", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_PartOrderItem_Order__OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_SparePart__SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SparePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IXF_Client__FirstName",
                table: "Client",
                column: "FirstName",
                filter: "FirstName IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client__Name",
                table: "Client",
                column: "Name",
                filter: "Name IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment__IsNode",
                table: "Equipment",
                column: "IsNode");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment__Name",
                table: "Equipment",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IXF_Equipment__ParentId",
                table: "Equipment",
                column: "ParentId",
                filter: "ParentId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EquipmentId",
                table: "Order",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order__StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrderItem__OrderId",
                table: "PartOrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrderItem_SparePartId",
                table: "PartOrderItem",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePart__IsNode",
                table: "SparePart",
                column: "IsNode");

            migrationBuilder.CreateIndex(
                name: "IXF_SparePart__ParentId",
                table: "SparePart",
                column: "ParentId",
                filter: "ParentId IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartOrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "SparePart");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ClientType");
        }
    }
}
