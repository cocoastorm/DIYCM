using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DiyCmDataModel.Construction;

namespace DiyCmDataModel.Migrations
{
    [DbContext(typeof(DiyCmContext))]
    [Migration("20160408014814_ThirdCreate")]
    partial class ThirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("DiyCmDataModel.Construction.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaRoom")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("AreaSquareFootage");

                    b.HasKey("AreaId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualAmount");

                    b.Property<decimal>("BudgetAmount");

                    b.Property<string>("CategoryName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("PercentCompleted");

                    b.Property<int>("ProjectId");

                    b.Property<decimal>("VarianceAmount");

                    b.HasKey("CategoryId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DocumentType")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Title");

                    b.HasKey("DocumentId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActualFinishDate");

                    b.Property<DateTime>("ActualStartDate");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("ProjectName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime>("ProjectedFinishDate");

                    b.Property<DateTime>("ProjectedStartDate");

                    b.HasKey("ProjectId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.QuoteDetail", b =>
                {
                    b.Property<int>("QuoteDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<int>("CategoryId")
                        .HasAnnotation("MaxLength", 6);

                    b.Property<int>("LineNumber");

                    b.Property<string>("Notes");

                    b.Property<string>("PartDescription")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("PartId")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("Quantity");

                    b.Property<int>("QuoteHeaderId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<int>("SubCategoryId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("QuoteDetailId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.QuoteHeader", b =>
                {
                    b.Property<int>("QuoteHeaderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressCity")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AddressCountry")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("AddressPostalCode")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("AddressProvince")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AddressStreet")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("ContactName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<char>("IsAccept");

                    b.Property<decimal>("PercentDiscount");

                    b.Property<string>("PhoneNumber")
                        .HasAnnotation("MaxLength", 13);

                    b.Property<string>("ReferredBy")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Supplier")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("notes");

                    b.HasKey("QuoteHeaderId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualAmount");

                    b.Property<decimal>("BudgetAmount");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("PercentCompleted");

                    b.Property<string>("SubCategoryName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("VarianceAmount");

                    b.HasKey("SubCategoryId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SupplierInvoiceDetail", b =>
                {
                    b.Property<int>("InvoiceId");

                    b.Property<int>("LineNumber");

                    b.Property<int>("AreaId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<int>("CategoryId")
                        .HasAnnotation("MaxLength", 6);

                    b.Property<string>("Notes");

                    b.Property<string>("PartDescription")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("PartNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("Quantity");

                    b.Property<int>("SubCategoryId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("InvoiceId", "LineNumber");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SupplierInvoiceHeader", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressCity")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AddressCountry")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("AddressPostalCode")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("AddressProvince")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("AddressStreet")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<char>("AmountPaid");

                    b.Property<string>("ContactName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PhoneNumber")
                        .HasAnnotation("MaxLength", 13);

                    b.Property<int>("QuoteHeaderId")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<string>("ReferredBy")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<decimal>("SH_AMOUNT");

                    b.Property<decimal>("SH_AMOUNT_PAID");

                    b.Property<string>("SupplierName")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("InvoiceId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.Category", b =>
                {
                    b.HasOne("DiyCmDataModel.Construction.Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.QuoteDetail", b =>
                {
                    b.HasOne("DiyCmDataModel.Construction.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("DiyCmDataModel.Construction.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("DiyCmDataModel.Construction.QuoteHeader")
                        .WithMany()
                        .HasForeignKey("QuoteHeaderId");

                    b.HasOne("DiyCmDataModel.Construction.SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SubCategory", b =>
                {
                    b.HasOne("DiyCmDataModel.Construction.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SupplierInvoiceDetail", b =>
                {
                    b.HasOne("DiyCmDataModel.Construction.Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("DiyCmDataModel.Construction.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("DiyCmDataModel.Construction.SupplierInvoiceHeader")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("DiyCmDataModel.Construction.SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");
                });

            modelBuilder.Entity("DiyCmDataModel.Construction.SupplierInvoiceHeader", b =>
                {
                    b.HasOne("DiyCmDataModel.Construction.QuoteHeader")
                        .WithMany()
                        .HasForeignKey("QuoteHeaderId");
                });
        }
    }
}
