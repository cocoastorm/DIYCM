using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    class SupplierInvoiceDetail
    {
        [MaxLength(20)]
        [ForeignKey("SupplierInvoiceHeader")]
        public string InvoiceId { get; set; }

        public int LineNumber { get; set; }

        [MaxLength(20)]
        public string PartNumber { get; set; }

        [MaxLength(255)]
        public string PartDescription { get; set; }

        [MaxLength(6)]
        [ForeignKey("SupplierInvoiceHeader")]
        public int? CategoryId { get; set; }

        [MaxLength(4)]
        [ForeignKey("SupplierInvoiceHeader")]
        public int? SubCategoryId { get; set; }

        [MaxLength(4)]
        [ForeignKey("SupplierInvoiceHeader")]
        public int? AreaId { get; set; }

        public float UnitPrice { get; set; }

        public string Notes { get; set; }
    }
}
