using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class SupplierInvoiceDetail
    {
        [Key, Column(Order = 0)]
        [ForeignKey("SupplierInvoiceHeader")]
        public int InvoiceId { get; set; }

        public SupplierInvoiceHeader SupplierInvoiceHeader { get; set; }

        [Key, Column(Order = 1)]
        public int LineNumber { get; set; }

        [MaxLength(20)]
        public string PartNumber { get; set; }

        [MaxLength(255)]
        public string PartDescription { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public Area Area { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Notes { get; set; }
    }
}
