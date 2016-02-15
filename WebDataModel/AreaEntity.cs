using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    public class AreaEntity
    {           
        [Key]
        [MaxLength(100)]
        public int AreaId { get; set; }

        [MaxLength(50)]
        public String AreaRoom { get; set; }

        public decimal AreaSquareFottage { get; set; }
    }
}
