using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_MVC_Ganesh.Models
{
    public class ReportTblMetaData
    {
        [DataType(DataType.Date)]
        [Display(Name = "Test Date")]
        [Required]
        public System.DateTime TestDate { get; set; }
        [Display(Name = "Test Summary")]
        [Required]
        public string TestSummary { get; set; }
        
        [Required]
        public int Laboratorian { get; set; }
        [Required]
        public int Patient { get; set; }
        
        [Required]
        public int TestName { get; set; }
    }
    [MetadataType(typeof(ReportTblMetaData))]
    public partial class ReportTbl
    {

    }
}