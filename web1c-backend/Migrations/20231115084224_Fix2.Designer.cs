﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web1c_backend.Models.Contexts;

#nullable disable

namespace web1cbackend.Migrations
{
    [DbContext(typeof(Web1cDBContext))]
    [Migration("20231115084224_Fix2")]
    partial class Fix2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web1c_backend.Models.Entities.En_debtor_card", b =>
                {
                    b.Property<long>("debtor_card_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("debtor_card_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("debtor_card_id"));

                    b.Property<long>("creation_date")
                        .HasColumnType("BIGINT")
                        .HasColumnName("creation_date");

                    b.Property<string>("debtor")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("debtor");

                    b.Property<string>("debtor_card_name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("debtor_card_name");

                    b.HasKey("debtor_card_id");

                    b.ToTable("Debtor_cards");
                });

            modelBuilder.Entity("web1c_backend.Models.Entities.En_history", b =>
                {
                    b.Property<long>("history_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("history_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("history_id"));

                    b.Property<long>("entity_id")
                        .HasColumnType("BIGINT")
                        .HasColumnName("entity_id");

                    b.Property<byte>("entity_type_id")
                        .HasColumnType("TINYINT")
                        .HasColumnName("entity_type_id");

                    b.Property<long?>("user_id")
                        .HasColumnType("BIGINT")
                        .HasColumnName("user_id");

                    b.HasKey("history_id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("web1c_backend.Models.Entities.En_session", b =>
                {
                    b.Property<long>("En_session_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("En_session_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("En_session_id"));

                    b.Property<long?>("En_user_id")
                        .HasColumnType("bigint")
                        .HasColumnName("En_user_id");

                    b.HasKey("En_session_id");

                    b.ToTable("En_session");
                });

            modelBuilder.Entity("web1c_backend.Models.Entities.En_user", b =>
                {
                    b.Property<long>("En_user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("En_user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("En_user_id"));

                    b.Property<string>("En_user_login")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("En_user_login");

                    b.Property<byte[]>("En_user_password")
                        .IsRequired()
                        .HasColumnType("varbinary(100)")
                        .HasColumnName("En_user_password");

                    b.HasKey("En_user_id");

                    b.ToTable("En_user");
                });
#pragma warning restore 612, 618
        }
    }
}
