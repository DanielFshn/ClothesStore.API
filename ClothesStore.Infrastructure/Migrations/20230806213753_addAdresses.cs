using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAdresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdressId",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AdressId",
                table: "OrderDetails",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Adresses_AdressId",
                table: "OrderDetails",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Adresses_AdressId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_AdressId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "OrderDetails");
        }
    }
}
