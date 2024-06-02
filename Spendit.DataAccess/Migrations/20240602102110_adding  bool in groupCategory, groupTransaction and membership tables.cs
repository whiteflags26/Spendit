using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpenditWeb.Migrations
{
    /// <inheritdoc />
    public partial class addingboolingroupCategorygroupTransactionandmembershiptables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Memberships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GroupTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "GroupCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GroupTransactions");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "GroupCategories");
        }
    }
}
