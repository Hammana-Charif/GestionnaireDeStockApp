﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataTransfertObject.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeCommuneEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibelleCommuneEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibellePaysEtrangerEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LibelleVoieEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroVoieEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeVoieEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DataTransfertObject.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivitePrincipaleUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdresseEtablissementAddressId")
                        .HasColumnType("int");

                    b.Property<string>("CategorieJuridiqueUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateCreationEtablissement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DenominationUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DenominationUsuelle1UniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomenclatureActivitePrincipaleUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SigleUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siren")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrancheEffectifsUniteLegale")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("AdresseEtablissementAddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DataTransfertObject.DataGridView.GiftCheque", b =>
                {
                    b.Property<int>("GiftChequeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("GiftChequeID");

                    b.ToTable("GiftCheques");
                });

            modelBuilder.Entity("DataTransfertObject.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountJoinId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductLineId")
                        .HasColumnType("int");

                    b.Property<double>("TotalDiscount")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("DiscountId");

                    b.HasIndex("ProductLineId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DataTransfertObject.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSeller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Recipe")
                        .HasColumnType("float");

                    b.Property<string>("TicketRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalToPay")
                        .HasColumnType("float");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DataTransfertObject.LoginSession", b =>
                {
                    b.Property<int>("LoginSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ConnectionDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ConnectionState")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginSessionId");

                    b.ToTable("LoginSessions");
                });

            modelBuilder.Entity("DataTransfertObject.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodJoinId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketInvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("PaymentMethodId");

                    b.HasIndex("TicketInvoiceId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("DataTransfertObject.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ExclTaxPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataTransfertObject.ProductLine", b =>
                {
                    b.Property<int>("ProductLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FinalTotalPrice")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductLineJoinId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int?>("TicketInvoiceId")
                        .HasColumnType("int");

                    b.HasKey("ProductLineId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TicketInvoiceId");

                    b.ToTable("ProductLines");
                });

            modelBuilder.Entity("DataTransfertObject.ProductStock", b =>
                {
                    b.Property<int>("ProductStockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("ProductStockId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductStocks");
                });

            modelBuilder.Entity("DataTransfertObject.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("PostalCode")
                        .HasColumnType("bigint");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProviderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("DataTransfertObject.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataTransfertObject.Company", b =>
                {
                    b.HasOne("DataTransfertObject.Address", "AdresseEtablissement")
                        .WithMany()
                        .HasForeignKey("AdresseEtablissementAddressId");
                });

            modelBuilder.Entity("DataTransfertObject.Discount", b =>
                {
                    b.HasOne("DataTransfertObject.ProductLine", "ProductLine")
                        .WithMany("Discounts")
                        .HasForeignKey("ProductLineId");
                });

            modelBuilder.Entity("DataTransfertObject.PaymentMethod", b =>
                {
                    b.HasOne("DataTransfertObject.Invoice", "Ticket")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("TicketInvoiceId");
                });

            modelBuilder.Entity("DataTransfertObject.ProductLine", b =>
                {
                    b.HasOne("DataTransfertObject.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("DataTransfertObject.Invoice", "Ticket")
                        .WithMany("ProductLines")
                        .HasForeignKey("TicketInvoiceId");
                });

            modelBuilder.Entity("DataTransfertObject.ProductStock", b =>
                {
                    b.HasOne("DataTransfertObject.Product", "Product")
                        .WithMany("ProductStocks")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("DataTransfertObject.Provider", b =>
                {
                    b.HasOne("DataTransfertObject.Product", "Product")
                        .WithMany("Providers")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
