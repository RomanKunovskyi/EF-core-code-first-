using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_core__code_first_.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAdvertisings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase = table.Column<string>(maxLength: 20, nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    Info = table.Column<string>(maxLength: 300, nullable: true),
                    Picture = table.Column<string>(nullable: true, defaultValueSql: "(N'\\DefoultPicture')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdvertisings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    Brand = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPeople",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<long>(nullable: true),
                    BornDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: true, defaultValue: "No address information")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPeople", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblPeople_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseHistories",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseHistories", x => new { x.ProductId, x.UserId, x.Date });
                    table.ForeignKey(
                        name: "FK_tblPurchaseHistories_tblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPurchaseHistories_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSpecialQuestions",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    Question = table.Column<string>(maxLength: 40, nullable: false),
                    Answer = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSpecialQuestions", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblSpecialQuestions_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPeople_PhoneNumber",
                table: "tblPeople",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseHistories_UserId",
                table: "tblPurchaseHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_Nickname",
                table: "tblUsers",
                column: "Nickname",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAdvertisings");

            migrationBuilder.DropTable(
                name: "tblPeople");

            migrationBuilder.DropTable(
                name: "tblPurchaseHistories");

            migrationBuilder.DropTable(
                name: "tblSpecialQuestions");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblUsers");
        }
    }
}
