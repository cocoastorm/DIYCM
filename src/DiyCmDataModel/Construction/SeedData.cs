using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class SeedData
    {
        public static void InitializeDocuments(DiyCmContext db)
        {
            if (!db.Documents.Any())
            {
                db.Documents.Add(new Document
                {
                   DocumentType = "Invoice",
                    Hyperlink = "http://a.b.c/invoice"
                });
                db.Documents.Add(new Document
                {
                    DocumentType = "Quotation",
                    Hyperlink = "http://a.b.c/quotation"
                });

                db.SaveChanges();
            }
        }


        public static void InitializeAreas(DiyCmContext db) {

        }

        public static void InitializeCategories(DiyCmContext db) {

        }

        public static void InitializeProjects(DiyCmContext db) {

        }

        public static void InitializeQuoteDetails(DiyCmContext db) {

        }

        public static void InitializeQuoteHeaders(DiyCmContext db) {

        }

        public static void InitializeSubCategories(DiyCmContext db) {

        }

        public static void InitializeSupplierInvoiceDetails(DiyCmContext db) {

        }

        public static void InitializeSupplierInvoiceHeaders(DiyCmContext db) {

        }
    }
}
