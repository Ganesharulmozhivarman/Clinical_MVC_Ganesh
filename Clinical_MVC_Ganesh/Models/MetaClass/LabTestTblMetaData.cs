using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Clinical_MVC_Ganesh.Models
{
    public class LabTestTblMetaData
    {
        [Display(Name = "Test Name")]
        [Required(ErrorMessage = "Test Name is required")]
        public string TestName { get; set; }
        [Required]
        public int TestCost { get; set; }
        [Display(Name = "Authorized Person")]
        [Required]
        public int AddBy { get; set; }
    }
    [MetadataType(typeof(LabTestTblMetaData))]
    public partial class LabTestTbl
    {

    }
}