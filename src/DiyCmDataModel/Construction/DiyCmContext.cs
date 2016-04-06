using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class DiyCmContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<QuoteDetail> QuoteDetails { get; set; }
        public DbSet<QuoteHeader> QuoteHeaders { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SupplierInvoiceHeader> SupplierInvoiceHeaders { get; set; }
        public DbSet<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Area>().HasKey(m => m.AreaId);

            builder.Entity<Category>().HasKey(m => m.CategoryId);

            builder.Entity<Document>().HasKey(m => m.DocumentId);

            builder.Entity<Project>().HasKey(m => m.ProjectId);

            builder.Entity<QuoteDetail>().HasKey(m => m.QuoteDetailId);

            builder.Entity<QuoteHeader>().HasKey(m => m.QuoteHeaderId);

            builder.Entity<SubCategory>().HasKey(m => m.SubCategoryId);


            builder.Entity<SupplierInvoiceHeader>().HasKey(m => m.InvoiceId);
            builder.Entity<SupplierInvoiceDetail>().HasKey(m => new { m.InvoiceId, m.LineNumber });
            base.OnModelCreating(builder);

          
            
        }

    }
}
