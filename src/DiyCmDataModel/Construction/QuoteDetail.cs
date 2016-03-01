using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class QuoteDetail
    {
        [Key]
        public int QuoteDetailId { get; set; }

        [MaxLength(4)]
       // [ForeignKey("QuoteHeader")]
        public int QuoteHeaderId { get; set; }

        public QuoteHeader QuoteHeader { get; set; }

        [MaxLength(20)]
        public string PartId { get; set; }

        [MaxLength(255)]
        public string PartDescription { get; set; }

        [MaxLength(6)]
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [MaxLength(4)]
        //[ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        [MaxLength(4)]
       // [ForeignKey("Area")]
        public int AreaId { get; set; }

        public Area Area { get; set; }

        public decimal UnitPrice { get; set; }

        public string Notes { get; set; }
    }
}
