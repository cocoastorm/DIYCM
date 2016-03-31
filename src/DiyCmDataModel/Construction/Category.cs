using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project ProjectEntity { get; set; }

        [MaxLength(30)]
        public string CategoryName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        // TOTAL OF ALL SUB-BUDGETS$
        public decimal BudgetAmount { get; set; }

        // TOTAL OF ALL SUB-ACTUAL$
        public decimal ActualAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.##}")]
        public decimal PercentCompleted { get; set; }

        // BudgetAmount - ActualAmount
        public decimal VarianceAmount { get; set; }
    }
}
