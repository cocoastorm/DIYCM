using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [MaxLength(50)]
        public String SubCategoryName { get; set; }

        [MaxLength(100)]
        public String Description { get; set; }

        [ForeignKey("MainCategoryEntity")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category MainCategoryEntity { get; set; }

        //TOTAL OF ALL QUOTES
        public decimal BudgetAmount { get; set; }

        //TOTAL OF ALL INVOICES
        public decimal ActualAmount { get; set; }

        public decimal PercentCompleted { get; set; }

        //SUB_BUDGET$-SUB_ACTUAL$
        public decimal VarianceAmount { get; set; }
    }
}
