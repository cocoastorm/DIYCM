using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WebDataModel
{
    public class Document
    {
        [MaxLength(10)]
        public int DocumentId { get; set; }
        [MaxLength(15)]
        public string DocumentType { get; set; }

        public HyperLink MyProperty { get; set; }
    }
}
