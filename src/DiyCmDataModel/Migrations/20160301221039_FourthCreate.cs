using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DiyCmDataModel.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaRoom = table.Column<string>(nullable: true),
                    AreaSquareFootage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualFinishDate = table.Column<DateTime>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectedFinishDate = table.Column<DateTime>(nullable: false),
                    ProjectedStartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });
            migrationBuilder.CreateTable(
                name: "QuoteHeader",
                columns: table => new
                {
                    QuoteHeaderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressCountry = table.Column<string>(nullable: true),
                    AddressPostalCode = table.Column<string>(nullable: true),
                    AddressProvince = table.Column<string>(nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IsAccept = table.Column<char>(nullable: false),
                    PercentDiscount = table.Column<decimal>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ReferredBy = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteHeader", x => x.QuoteHeaderId);
                });
            migrationBuilder.CreateTable(
                name: "SupplierInvoiceHeader",
                columns: table => new
                {
                    QuoteHeaderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressCountry = table.Column<string>(nullable: true),
                    AddressPostalCode = table.Column<string>(nullable: true),
                    AddressProvince = table.Column<string>(nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<char>(nullable: false),
                    ContactName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ReferredBy = table.Column<string>(nullable: true),
                    SH_AMOUNT = table.Column<decimal>(nullable: false),
                    SH_AMOUNT_PAID = table.Column<decimal>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceHeader", x => x.QuoteHeaderId);
                });
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualAmount = table.Column<decimal>(nullable: false),
                    BudgetAmount = table.Column<decimal>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PercentCompleted = table.Column<decimal>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    VarianceAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualAmount = table.Column<decimal>(nullable: false),
                    BudgetAmount = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PercentCompleted = table.Column<decimal>(nullable: false),
                    SubCategoryName = table.Column<string>(nullable: true),
                    VarianceAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "QuoteDetail",
                columns: table => new
                {
                    QuoteDetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(nullable: true),
                    QuoteHeaderId = table.Column<int>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteDetail", x => x.QuoteDetailId);
                    table.ForeignKey(
                        name: "FK_QuoteDetail_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteDetail_QuoteHeader_QuoteHeaderId",
                        column: x => x.QuoteHeaderId,
                        principalTable: "QuoteHeader",
                        principalColumn: "QuoteHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteDetail_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SupplierInvoiceDetail",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(nullable: false),
                    LineNumber = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PartDescription = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    SupplierInvoiceHeaderQuoteHeaderId = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierInvoiceDetail", x => new { x.InvoiceId, x.LineNumber });
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceDetail_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceDetail_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierInvoiceDetail_SupplierInvoiceHeader_SupplierInvoiceHeaderQuoteHeaderId",
                        column: x => x.SupplierInvoiceHeaderQuoteHeaderId,
                        principalTable: "SupplierInvoiceHeader",
                        principalColumn: "QuoteHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("QuoteDetail");
            migrationBuilder.DropTable("SupplierInvoiceDetail");
            migrationBuilder.DropTable("QuoteHeader");
            migrationBuilder.DropTable("Area");
            migrationBuilder.DropTable("SubCategory");
            migrationBuilder.DropTable("SupplierInvoiceHeader");
            migrationBuilder.DropTable("Category");
            migrationBuilder.DropTable("Project");
        }
    }
}
