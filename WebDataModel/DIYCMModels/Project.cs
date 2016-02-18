using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDataModel {
    public class Project {
        [Key]
        public int ProjectId { get; set; }

        [MaxLength(100)]
        public string ProjectName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime ProjectedStartDate { get; set; }

        public DateTime ActualStartDate { get; set; }

        public DateTime ProjectedFinishDate { get; set; }

        public DateTime ActualFinishDate { get; set; }
    }
}
