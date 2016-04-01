using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DiyCmDataModel.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Category_Project_ProjectId", table: "Category");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_Area_AreaId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_Category_CategoryId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_QuoteHeader_QuoteHeaderId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_SubCategory_SubCategoryId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_SubCategory_Category_CategoryId", table: "SubCategory");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_Area_AreaId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_Category_CategoryId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_SubCategory_SubCategoryId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_SupplierInvoiceHeader_SupplierInvoiceHeaderQuoteHeaderId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropColumn(name: "SupplierInvoiceHeaderQuoteHeaderId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropColumn(name: "Hyperlink", table: "Document");
            migrationBuilder.AddColumn<string>(
                name: "InvoiceId1",
                table: "SupplierInvoiceHeader",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddUniqueConstraint(
                name: "AK_SupplierInvoiceHeader_InvoiceId1",
                table: "SupplierInvoiceHeader",
                column: "InvoiceId1");
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SupplierInvoiceDetail",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "LineNumber",
                table: "QuoteDetail",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "QuoteDetail",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Document",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Category_Project_ProjectId",
                table: "Category",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_Area_AreaId",
                table: "QuoteDetail",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_Category_CategoryId",
                table: "QuoteDetail",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_QuoteHeader_QuoteHeaderId",
                table: "QuoteDetail",
                column: "QuoteHeaderId",
                principalTable: "QuoteHeader",
                principalColumn: "QuoteHeaderId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_SubCategory_SubCategoryId",
                table: "QuoteDetail",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_Area_AreaId",
                table: "SupplierInvoiceDetail",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_Category_CategoryId",
                table: "SupplierInvoiceDetail",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_SupplierInvoiceHeader_InvoiceId",
                table: "SupplierInvoiceDetail",
                column: "InvoiceId",
                principalTable: "SupplierInvoiceHeader",
                principalColumn: "InvoiceId1",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_SubCategory_SubCategoryId",
                table: "SupplierInvoiceDetail",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Category_Project_ProjectId", table: "Category");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_Area_AreaId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_Category_CategoryId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_QuoteHeader_QuoteHeaderId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_QuoteDetail_SubCategory_SubCategoryId", table: "QuoteDetail");
            migrationBuilder.DropForeignKey(name: "FK_SubCategory_Category_CategoryId", table: "SubCategory");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_Area_AreaId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_Category_CategoryId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_SupplierInvoiceHeader_InvoiceId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropForeignKey(name: "FK_SupplierInvoiceDetail_SubCategory_SubCategoryId", table: "SupplierInvoiceDetail");
            migrationBuilder.DropUniqueConstraint(name: "AK_SupplierInvoiceHeader_InvoiceId1", table: "SupplierInvoiceHeader");
            migrationBuilder.DropColumn(name: "InvoiceId1", table: "SupplierInvoiceHeader");
            migrationBuilder.DropColumn(name: "Quantity", table: "SupplierInvoiceDetail");
            migrationBuilder.DropColumn(name: "LineNumber", table: "QuoteDetail");
            migrationBuilder.DropColumn(name: "Quantity", table: "QuoteDetail");
            migrationBuilder.DropColumn(name: "Title", table: "Document");
            migrationBuilder.AddColumn<int>(
                name: "SupplierInvoiceHeaderQuoteHeaderId",
                table: "SupplierInvoiceDetail",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Hyperlink",
                table: "Document",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Category_Project_ProjectId",
                table: "Category",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_Area_AreaId",
                table: "QuoteDetail",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_Category_CategoryId",
                table: "QuoteDetail",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_QuoteHeader_QuoteHeaderId",
                table: "QuoteDetail",
                column: "QuoteHeaderId",
                principalTable: "QuoteHeader",
                principalColumn: "QuoteHeaderId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_QuoteDetail_SubCategory_SubCategoryId",
                table: "QuoteDetail",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_Area_AreaId",
                table: "SupplierInvoiceDetail",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_Category_CategoryId",
                table: "SupplierInvoiceDetail",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_SubCategory_SubCategoryId",
                table: "SupplierInvoiceDetail",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoiceDetail_SupplierInvoiceHeader_SupplierInvoiceHeaderQuoteHeaderId",
                table: "SupplierInvoiceDetail",
                column: "SupplierInvoiceHeaderQuoteHeaderId",
                principalTable: "SupplierInvoiceHeader",
                principalColumn: "QuoteHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
