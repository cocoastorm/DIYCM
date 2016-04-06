using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.Construction
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        [MaxLength(15)]
        public string DocumentType { get; set; }

        public string Title { get; set; }
        //public string Hyperlink { get; set; }
    }
}
