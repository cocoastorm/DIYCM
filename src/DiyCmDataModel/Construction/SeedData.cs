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
            if (!db.Areas.Any()) {
                db.Areas.Add(new Area
                {
                    AreaId = 1,
                    AreaRoom = "Kitchen",
                    AreaSquareFootage = 222.22M
                });
                db.Areas.Add(new Area
                {
                    AreaId = 2,
                    AreaRoom = "Main Floor Bath",
                    AreaSquareFootage = 100.23M
                });
                db.Areas.Add(new Area
                {
                    AreaId = 3,
                    AreaRoom = "Second Floor Bath",
                    AreaSquareFootage = 123.12M
                });
                db.Areas.Add(new Area
                {
                    AreaId = 4,
                    AreaRoom = "EnSuite",
                    AreaSquareFootage = 50.44M
                });
                db.Areas.Add(new Area
                {
                    AreaId = 5,
                    AreaRoom = "Laundry Room",
                    AreaSquareFootage = 67.34M
                });
                db.SaveChanges();
            }

        }

        public static void InitializeProjects(DiyCmContext db)
        {
            if (!db.Projects.Any())
            {
                db.Projects.Add(new Project
                {
                    ProjectId = 100,
                    ProjectName = "First Construction Project",
                    Description = "My first construction project with DIYCM",
                    ProjectedStartDate = new DateTime(2016, 5, 16),
                    ActualStartDate = new DateTime(2016, 03, 01),
                    ProjectedFinishDate = new DateTime(2015, 08, 20)

                });
            }
        }


        public static void InitializeCategories(DiyCmContext db) {
            if(!db.Categories.Any()){
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 100,
                    CategoryName = "Design",
                    Description = "A category"

                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 110,
                    CategoryName = "Permits"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 120,
                    CategoryName = "Demolition"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 130,
                    CategoryName = "Excavation"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 140,
                    CategoryName = "Arborist"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 150,
                    CategoryName = "Foundation"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 160,
                    CategoryName = "Framing"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 170,
                    CategoryName = "Plumbing"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 180,
                    CategoryName = "Drywall"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 190,
                    CategoryName = "Electrical"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 200,
                    CategoryName = "Siding"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 210,
                    CategoryName = "Painting"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 220,
                    CategoryName = "Flooring"
                });
                db.Categories.Add(new Category
                {
                    ProjectId = 100,
                    CategoryId = 230,
                    CategoryName = "Security"
                });

                db.SaveChanges();
            }
        
        }

        public static void InitializeSubCategories(DiyCmContext db)
        {
            if (!db.SubCategories.Any())
            {
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 10,
                    SubCategoryName = "Rough In",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 20,
                    SubCategoryName = "Faucet",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 30,
                    SubCategoryName = "Sink",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 40,
                    SubCategoryName = "Bathtub",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 50,
                    SubCategoryName = "Shower",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 60,
                    SubCategoryName = "Toilet",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 70,
                    SubCategoryName = "Bathtub Trim Set",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 80,
                    SubCategoryName = "Drain",
                    CategoryId = 170,
                });
                db.SubCategories.Add(new SubCategory
                {
                    SubCategoryId = 90,
                    SubCategoryName = "Hose Bib",
                    CategoryId = 170,
                });
                db.SaveChanges();
            }
        }
   

        public static void InitializeQuoteHeaders(DiyCmContext db)
        {
            if (!db.QuoteHeaders.Any())
            {
                db.QuoteHeaders.Add(new QuoteHeader()
                {
                    QuoteHeaderId = 12345,
                    Supplier = "John's Plumbing",
                    StartDate = new DateTime(2016, 3, 20),
                    ContactName = "John Smith",
                    PhoneNumber = "(604)555-5254",
                    ReferredBy = "Billy",
                    AddressStreet = "123 Main Street",
                    AddressCity = "Surrey",
                    AddressProvince = "BC",
                    AddressPostalCode = "V3L 3M3",
                    ExpiryDate = new DateTime(2016, 1, 31),
                    PercentDiscount = 5,
                });

                db.SaveChanges();
            }

        }

        public static void InitializeQuoteDetails(DiyCmContext db)
        {
            if (!db.QuoteDetails.Any())
            {
                db.QuoteDetails.Add(new QuoteDetail()
                {
                    QuoteDetailId = 1,
                    QuoteHeaderId = 12345,
                    PartId = "32542",
                    PartDescription = "Chrome Tap",
                    CategoryId = 170,
                    SubCategoryId = 20,
                    AreaId = 2,
                    UnitPrice = 200.00M,
                    Notes = "",
                });

                db.QuoteDetails.Add(new QuoteDetail()
                {
                    QuoteDetailId = 2,
                    QuoteHeaderId = 12345,
                    PartId = "62584",
                    PartDescription = "Glass Sink",
                    CategoryId = 170,
                    SubCategoryId = 30,
                    AreaId = 2,
                    UnitPrice = 300.00M,
                    Notes = "",
                });

                db.QuoteDetails.Add(new QuoteDetail()
                {
                    QuoteDetailId = 3,
                    QuoteHeaderId = 12345,
                    PartId = "3DI34",
                    PartDescription = "Sink Stopper",
                    CategoryId = 170,
                    SubCategoryId = 30,
                    AreaId = 2,
                    UnitPrice = 75.00M,
                    Notes = "Special for glass sink",
                });

                db.SaveChanges();
            }
        }

        
        public static void InitializeSupplierInvoiceDetails(DiyCmContext db) {

        }

        public static void InitializeSupplierInvoiceHeaders(DiyCmContext db) {

        }
    }
}
