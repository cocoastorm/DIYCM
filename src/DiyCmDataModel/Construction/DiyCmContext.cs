using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class DiyCmContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Document>().HasKey(m => m.DocumentId);
            base.OnModelCreating(builder);
        }

    }
}
