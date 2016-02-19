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

    }
}
