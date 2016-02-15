using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    class SupplierInvoiceHeader
    {
        [MaxLength(20)]
        [Key]
        public string InvoiceId { get; set; }

        [MaxLength(50)]
        public string SupplierName { get; set; }

        [MaxLength(4)]
        public int QuoteHeaderId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(50)]
        public string ContactName { get; set; }

        [MaxLength(13)]
        public string PhoneNumber { get; set; }

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

        public Boolean AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal SH_AMOUNT { get; set; }

        public decimal SH_AMOUNT_PAID { get; set; }
    }
}
