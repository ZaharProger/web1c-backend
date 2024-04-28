using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web1cbackend.Migrations
{
    /// <inheritdoc />
    public partial class EN1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "debtor_card_name",
                table: "Debtor_cards",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AlterColumn<string>(
                name: "debtor",
                table: "Debtor_cards",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AddColumn<double>(
                name: "DebtorPaymentArrears",
                table: "Debtor_cards",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inn",
                table: "Debtor_cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBankrupt",
                table: "Debtor_cards",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInCreditorsList",
                table: "Debtor_cards",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSmp",
                table: "Debtor_cards",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kpp",
                table: "Debtor_cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sanctions",
                table: "Debtor_cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebtorPaymentArrears",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "Inn",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "IsBankrupt",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "IsInCreditorsList",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "IsSmp",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "Kpp",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "Sanctions",
                table: "Debtor_cards");

            migrationBuilder.AlterColumn<string>(
                name: "debtor_card_name",
                table: "Debtor_cards",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "debtor",
                table: "Debtor_cards",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);
        }
    }
}
