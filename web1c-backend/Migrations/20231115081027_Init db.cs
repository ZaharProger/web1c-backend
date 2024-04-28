using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web1cbackend.Migrations
{
    /// <inheritdoc />
    public partial class Initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debtor_Agreement");

            migrationBuilder.DropTable(
                name: "Event_records");

            migrationBuilder.DropColumn(
                name: "debtor_id",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "emergency_message_id",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "inn",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "is_bankrupt",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "is_in_creditors_list",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "is_smp",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "kpp",
                table: "Debtor_cards");

            migrationBuilder.DropColumn(
                name: "sanctions",
                table: "Debtor_cards");

            migrationBuilder.AlterColumn<long>(
                name: "creation_date",
                table: "Debtor_cards",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AlterColumn<long>(
                name: "debtor_card_id",
                table: "Debtor_cards",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "debtor",
                table: "Debtor_cards",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    historyid = table.Column<long>(name: "history_id", type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entitytypeid = table.Column<byte>(name: "entity_type_id", type: "TINYINT", nullable: false),
                    entityid = table.Column<long>(name: "entity_id", type: "BIGINT", nullable: false),
                    userid = table.Column<long>(name: "user_id", type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.historyid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropColumn(
                name: "debtor",
                table: "Debtor_cards");

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "Debtor_cards",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<int>(
                name: "debtor_card_id",
                table: "Debtor_cards",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "debtor_id",
                table: "Debtor_cards",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "emergency_message_id",
                table: "Debtor_cards",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "inn",
                table: "Debtor_cards",
                type: "VARCHAR(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_bankrupt",
                table: "Debtor_cards",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_in_creditors_list",
                table: "Debtor_cards",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_smp",
                table: "Debtor_cards",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "kpp",
                table: "Debtor_cards",
                type: "VARCHAR(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sanctions",
                table: "Debtor_cards",
                type: "VARCHAR(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Debtor_Agreement",
                columns: table => new
                {
                    debtorid = table.Column<int>(name: "debtor_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marketview = table.Column<string>(name: "Market_view", type: "varchar(200)", nullable: false),
                    baseid = table.Column<int>(name: "base_id", type: "int", nullable: false),
                    budgetid = table.Column<int>(name: "budget_id", type: "int", nullable: false),
                    businessid = table.Column<int>(name: "business_id", type: "int", nullable: false),
                    comment = table.Column<string>(type: "varchar(1000)", nullable: false),
                    counterid = table.Column<int>(name: "counter_id", type: "int", nullable: false),
                    currencyid = table.Column<int>(name: "currency_id", type: "int", nullable: false),
                    dateagreement = table.Column<DateTime>(name: "date_agreement", type: "DATETIME", nullable: false),
                    debtorname = table.Column<string>(name: "debtor_name", type: "varchar(200)", nullable: false),
                    disabledstatus = table.Column<bool>(name: "disabled_status", type: "bit", nullable: false),
                    numberagreement = table.Column<string>(name: "number_agreement", type: "varchar(200)", nullable: false),
                    paymentid = table.Column<int>(name: "payment_id", type: "int", nullable: false),
                    publicstatus = table.Column<bool>(name: "public_status", type: "bit", nullable: false),
                    responsible = table.Column<string>(type: "varchar(100)", nullable: false),
                    societyid = table.Column<int>(name: "society_id", type: "int", nullable: false),
                    statusagreement = table.Column<string>(name: "status_agreement", type: "varchar(30)", nullable: false),
                    turnoverid = table.Column<int>(name: "turnover_id", type: "int", nullable: false),
                    typicalstatus = table.Column<bool>(name: "typical_status", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debtor_Agreement", x => x.debtorid);
                });

            migrationBuilder.CreateTable(
                name: "Event_records",
                columns: table => new
                {
                    eventrecordid = table.Column<int>(name: "event_record_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    basedocumentid = table.Column<int>(name: "base_document_id", type: "INT", nullable: false),
                    businessid = table.Column<int>(name: "business_id", type: "INT", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "INT", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "DATETIME", nullable: false),
                    debtorcardid = table.Column<int>(name: "debtor_card_id", type: "INT", nullable: false),
                    eventcomment = table.Column<string>(name: "event_comment", type: "VARCHAR(1000)", nullable: false),
                    eventdescription = table.Column<string>(name: "event_description", type: "VARCHAR(1000)", nullable: false),
                    executiondate = table.Column<DateTime>(name: "execution_date", type: "DATETIME", nullable: false),
                    expexecutiondate = table.Column<DateTime>(name: "exp_execution_date", type: "DATETIME", nullable: false),
                    responsibleuser = table.Column<string>(name: "responsible_user", type: "VARCHAR(50)", nullable: false),
                    senddate = table.Column<DateTime>(name: "send_date", type: "DATETIME", nullable: false),
                    worktypeid = table.Column<int>(name: "work_type_id", type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_records", x => x.eventrecordid);
                });
        }
    }
}
