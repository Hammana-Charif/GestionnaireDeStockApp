﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataLayer.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20200606164447_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Product", b =>
                {
                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Reference");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Ticket", b =>
            {
                b.Property<string>("TicketRef")
                   .HasColumnType("long");

                b.Property<string>("NameSeller")
                    .HasColumnType("nvarchar(max)");

                b.Property<double>("Recipe")
                    .HasColumnType("double");

                b.Property<double>("Discount")
                    .HasColumnType("double");

                b.Property<string>("PaymentMethod")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreationDate")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("TicketRef");

                b.ToTable("Tickets");
            });
            #pragma warning restore 612, 618
        }
    }
}
