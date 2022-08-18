using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Clinical_MVC_Ganesh.Models
{
    public class PatientTblMetaData
    {
        [Display(Name = "Patient Name")]
        [Required(ErrorMessage = "Patient Name is required")]
        public string PatName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PatPhone { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public string PatGen { get; set; }
        public System.DateTime PatDOB { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string PatAdd { get; set; }

        [Display(Name = "Allergies ")]
        [Required]
        public string PatAllegies { get; set; }

        [Display(Name = "Enrolled By ")]
        [Required]
        public int AddBy { get; set; }
    }
    [MetadataType(typeof(PatientTblMetaData))]
    public partial class PatientTbl
    {

    }
}