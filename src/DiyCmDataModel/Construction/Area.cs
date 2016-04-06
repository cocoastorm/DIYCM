using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        [MaxLength(50)]
        public String AreaRoom { get; set; }

        [DisplayFormat(DataFormatString = "{0:#####.##}")]
        public decimal AreaSquareFootage { get; set; }
    }
}
