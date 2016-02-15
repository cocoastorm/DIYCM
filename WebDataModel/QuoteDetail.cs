using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    public class QuoteDetail
    {
        [Key]
        public int QuoteDetailId { get; set; }
        [MaxLength(4)]
        [ForeignKey("QuoteHeader")]
        public int? QuoteHeaderId { get; set; }
        [MaxLength(20)]
        public string PartId { get; set; }
        [MaxLength(255)]
        public string PartDescription { get; set; }
        [MaxLength(6)]
        //[ForeignKey("MainCategoryEntity")]
        public int? CategoryId { get; set; }
        [MaxLength(4)]
        //[ForeignKey("SubcategoryEntity")]
        public int? SubCategoryId { get; set; }
        [MaxLength(4)]
        //[ForeignKey("AreaEntity")]
        public int? AreaId { get; set; }
        public float UnitPrice { get; set; }
        public string Notes { get; set; }
    }
}
