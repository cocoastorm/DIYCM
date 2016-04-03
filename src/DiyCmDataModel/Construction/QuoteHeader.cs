using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class QuoteHeader
    {
        [Key]
        public int QuoteHeaderId { get; set; }

        [MaxLength(50)]
        public string Supplier { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartDate { get; set; }

        [MaxLength(50)]
        public string ReferredBy { get; set; }

        [MaxLength(100)]
        public string AddressStreet { get; set; }

        [MaxLength(30)]
        public string AddressCity { get; set; }

        [MaxLength(30)]
        public string AddressProvince { get; set; }

        [MaxLength(15)]
        public string AddressPostalCode { get; set; }

        [MaxLength(15)]
        public string AddressCountry { get; set; }

        public DateTime ExpiryDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:###.##}")]
        public decimal PercentDiscount { get; set; }

        public string notes { get; set; }

        [RegularExpression("Y|N")]
        public char IsAccept { get; set; }

        [MaxLength(50)]
        public string ContactName { get; set; }

        [MaxLength(13)]
        public string PhoneNumber { get; set; }
    }
}
