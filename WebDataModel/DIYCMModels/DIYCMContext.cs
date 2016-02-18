using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel.DIYCMModels
{
    class DIYCMContext: DbContext
    {
        public DIYCMContext()
            : base("DefaultConnection")
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }
        public DbSet<SupplierInvoiceHeader> SupplierInvoiceHeaders { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<QuoteHeader> QuoteHeaders { get; set; }
        public DbSet<QuoteDetail> QuoteDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
